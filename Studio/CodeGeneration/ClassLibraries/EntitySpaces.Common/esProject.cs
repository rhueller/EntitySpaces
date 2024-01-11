using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.Common
{
    public class EsProject
    {
        public EsProjectNode RootNode;

        // used in serialized project file
        private const string EsProjectVersion = "2019.1.0.0";

        private esSettings _userSettings;
        private string _projectFilePath = "";

        public void Load(string fileNameAndFilePath, esSettings mainSettings)
        {
            _userSettings = mainSettings;

            var version = GetFileVersion(fileNameAndFilePath);

            if (version != null && version.Substring(0, 4) != "2012" && version.Substring(0, 4) != "2019")
            {
                // Convert the old project file in place
                // ConvertProject(fileNameAndFilePath, mainSettings);
            }

            RootNode = null;

            var parents = new Dictionary<int, EsProjectNode>();

            using (var reader = new XmlTextReader(fileNameAndFilePath))
            {
                _projectFilePath = fileNameAndFilePath;
                reader.WhitespaceHandling = WhitespaceHandling.None;

                reader.Read();
                reader.Read();

                if (reader.Name != "EntitySpacesProject")
                {
                    throw new Exception($"Invalid Project File: '{fileNameAndFilePath}'");
                }

                reader.Read();

                var currentNode = new EsProjectNode
                {
                    Name = reader.GetAttribute("Name")
                };
                RootNode = currentNode;

                parents[reader.Depth] = currentNode;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.LocalName)
                        {
                            case "Folder":

                                currentNode = new EsProjectNode
                                {
                                    Name = reader.GetAttribute("Name")
                                };

                                parents[reader.Depth - 1].Children.Add(currentNode);
                                parents[reader.Depth] = currentNode;
                                break;

                            case "RecordedTemplate":

                                currentNode = new EsProjectNode
                                {
                                    Name = reader.GetAttribute("Name"),
                                    IsFolder = false
                                };

                                var depth = reader.Depth;

                                // <Template>
                                reader.Read();
                                currentNode.Template = new Template();

                                // Path fixup to the template
                                var path = reader.GetAttribute("Path");
                                path = path.Replace("{fixup}", _userSettings.TemplatePath);
                                path = path.Replace("\\\\", "\\");

                                currentNode.Template.Parse(path);

                                // <Input>
                                reader.Read();
                                var input = reader.ReadSubtree();
                                input.Read();

                                currentNode.Input = new Hashtable();

                                while (input.Read())
                                {
                                    var type = input.GetAttribute("Type");
                                    var key = input.GetAttribute("Key");
                                    var value = input.GetAttribute("Value");

                                    if (key == "OutputPath")
                                    {
                                        value = FixupTheFixup(this._projectFilePath, value);
                                    }

                                    switch (type)
                                    {
                                        case "(null)":
                                            currentNode.Input[key] = null;
                                            break;

                                        case "System.String":
                                            currentNode.Input[key] = value;
                                            break;

                                        case "System.Char":
                                            currentNode.Input[key] = Convert.ToChar(value);
                                            break;

                                        case "System.DateTime":
                                            currentNode.Input[key] = Convert.ToDateTime(value);
                                            break;

                                        case "System.Decimal":
                                            currentNode.Input[key] = Convert.ToDecimal(value);
                                            break;

                                        case "System.Double":
                                            currentNode.Input[key] = Convert.ToDouble(value);
                                            break;

                                        case "System.Boolean":
                                            currentNode.Input[key] = Convert.ToBoolean(value);
                                            break;

                                        case "System.Int16":
                                            currentNode.Input[key] = Convert.ToInt16(value);
                                            break;

                                        case "System.Int32":
                                            currentNode.Input[key] = Convert.ToInt32(value);
                                            break;

                                        case "System.Int64":
                                            currentNode.Input[key] = Convert.ToInt64(value);
                                            break;

                                        case "System.Collections.ArrayList":

                                            var list = new ArrayList();
                                            var items = value.Split(',');

                                            foreach (var item in items)
                                            {
                                                list.Add(item);
                                            }

                                            currentNode.Input[key] = list;
                                            break;
                                    }
                                }

                                // <Settings>
                                reader.Read();
                                var settings = reader.ReadSubtree();

                                currentNode.Settings = new esSettings();
                                currentNode.Settings = esSettings.Load(settings);

                                // Fixup Settings ...
                                currentNode.Settings.TemplatePath = _userSettings.TemplatePath;
                                currentNode.Settings.OutputPath = _userSettings.OutputPath;
                                currentNode.Settings.UIAssemblyPath = _userSettings.UIAssemblyPath;
                                currentNode.Settings.CompilerAssemblyPath = _userSettings.CompilerAssemblyPath;
                                currentNode.Settings.LanguageMappingFile = _userSettings.LanguageMappingFile;
                                currentNode.Settings.UserMetadataFile = _userSettings.UserMetadataFile;

                                parents[depth - 1].Children.Add(currentNode);
                                break;
                        }
                    }
                }
            }
        }

        private string GetFileVersion(string fileNameAndFilePath)
        {
            var version = "0000.0.0000.0";

            try
            {
                using (var reader = new XmlTextReader(fileNameAndFilePath))
                {
                    _projectFilePath = fileNameAndFilePath;
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    reader.Read();
                    reader.Read();

                    version = reader[0];
                }
            }
            catch
            {
                // ignored
            }

            return version;
        }

        public void Save(string fileNameAndFilePath, esSettings mainSettings)
        {
            _projectFilePath = fileNameAndFilePath;
            _userSettings = mainSettings;

            var writer = new XmlTextWriter(fileNameAndFilePath, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("EntitySpacesProject");
            writer.WriteAttributeString("Version", EsProjectVersion);
            Save(this.RootNode, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void Save(EsProjectNode node, XmlTextWriter writer)
        {
            BeginWriteNode(node, writer);

            foreach (var childNode in node.Children.Cast<EsProjectNode>())
            {
                Save(childNode, writer);
            }

            EndWriteNode(node, writer);
        }

        private void BeginWriteNode(IProjectNode node, XmlTextWriter writer)
        {
            if (node.IsFolder)
            {
                writer.WriteStartElement("Folder");
                writer.WriteAttributeString("Name", node.Name);
            }
            else
            {
                writer.WriteStartElement("RecordedTemplate");
                writer.WriteAttributeString("Name", node.Name);

                writer.WriteStartElement("Template");
                writer.WriteAttributeString("Name", node.Template.Header.Title);
                writer.WriteAttributeString("Path", node.Template.Header.FullFileName.Replace(_userSettings.TemplatePath, "{fixup}"));
                writer.WriteAttributeString("Version", node.Template.Header.Version);
                writer.WriteEndElement();

                writer.WriteStartElement("Input");
                if (node.Input.Count > 0)
                {
                    foreach (string key in node.Input.Keys)
                    {
                        var value = node.Input[key];

                        if (key == "OutputPath")
                        {
                             value = CreateFixup(this._projectFilePath, (string)value);
                        }

                        if (value == null)
                        {
                            writer.WriteStartElement("Item");
                            writer.WriteAttributeString("Type", "(null)");
                            writer.WriteAttributeString("Key", key);
                            writer.WriteEndElement();
                            continue;
                        }

                        var typeName = value.GetType().FullName;

                        writer.WriteStartElement("Item");
                        writer.WriteAttributeString("Type", typeName ?? string.Empty);
                        writer.WriteAttributeString("Key", key);

                        switch (typeName)
                        {
                            case "System.Collections.ArrayList":

                                var list = value as ArrayList;

                                var values = "";
                                var comma = "";

                                if (list != null)
                                    foreach (string s in list)
                                    {
                                        values += comma;
                                        values += s;
                                        comma = ",";
                                    }

                                writer.WriteAttributeString("Value", values);
                                break;

                            default:

                                writer.WriteAttributeString("Value", value.ToString());
                                break;
                        }

                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();

                // Save these off so we can restore them
                var bakTemplatePath = node.Settings.TemplatePath;
                var bakOutputPath = node.Settings.OutputPath;
                var bakUiAssemblyPath = node.Settings.UIAssemblyPath;
                var bakCompilerAssemblyPath = node.Settings.CompilerAssemblyPath;
                var bakLanguageMappingFile = node.Settings.LanguageMappingFile;
                var bakUserMetadataFile = node.Settings.UserMetadataFile;

                // Remove Hard coded Paths
                node.Settings.TemplatePath = "{fixup}";
                node.Settings.OutputPath = "{fixup}";
                node.Settings.UIAssemblyPath = "{fixup}";
                node.Settings.CompilerAssemblyPath = "{fixup}";
                node.Settings.LanguageMappingFile = "{fixup}";
                node.Settings.UserMetadataFile = "{fixup}";

                // Now write it
                node.Settings.Save(writer);
                writer.WriteEndElement();

                // Restore the original values
                node.Settings.TemplatePath = bakTemplatePath;
                node.Settings.OutputPath = bakOutputPath;
                node.Settings.UIAssemblyPath = bakUiAssemblyPath;
                node.Settings.CompilerAssemblyPath = bakCompilerAssemblyPath;
                node.Settings.LanguageMappingFile = bakLanguageMappingFile;
                node.Settings.UserMetadataFile = bakUserMetadataFile;
            }
        }

        private static void EndWriteNode(IProjectNode node, XmlWriter writer)
        {
            if (node.IsFolder)
            {
                writer.WriteEndElement();
            }
        }

        private static string CreateFixup(string projectFile, string outputDir)
        {
            var prjPath = Path.GetDirectoryName(projectFile.ToLower());
            var outPath = outputDir.ToLower();

            var sep = Path.DirectorySeparatorChar;

            var prjPathParts = prjPath?.Split(sep);
            var outPathParts = outPath.Split(sep);

            var i = 0;
            while (true)
            {
                if (prjPathParts != null && prjPathParts.Length > i && outPathParts.Length > i)
                {
                    if (prjPathParts[i] == outPathParts[i])
                    {
                        i++;
                    }
                    else break;
                }
                else break;
            }

            if (i > 1)
            {
                var iBackup = i;

                // At this point "i" is where the paths deviate

                //=====================================================
                // Do We need any \.. path relative stuff?
                //=====================================================
                var fixup = "{fixup";
                while (true)
                {
                    if (prjPathParts != null && prjPathParts.Length > i)
                    {
                        fixup += @"\..";
                        i++;
                    }
                    else break;
                }

                i = iBackup;
                while (true)
                {
                    if (outPathParts.Length > i)
                    {
                        fixup += sep;
                        fixup += outPathParts[i];
                        i++;
                    }
                    else break;
                }

                return fixup + "}";
            }
            else
            {
                return outputDir;
            }
        }

        private string FixupTheFixup(string projectFile, string outputDir)
        {
            if (!outputDir.StartsWith("{")) return outputDir;

            var outputPath = outputDir.Replace("{fixup", "").Replace("}", "");
            var prjPath = Path.GetDirectoryName(projectFile.ToLower());

            var sep = Path.DirectorySeparatorChar;

            var prjPathParts = prjPath?.Split(sep);
            if (prjPathParts != null)
            {
                var index = prjPathParts.Length;

                var loc = 0;
                while (true)
                {
                    loc = outputPath.IndexOf(@"\..", loc, StringComparison.Ordinal);

                    if (loc != -1)
                    {
                        prjPathParts[--index] = "";
                        loc += 3;
                    }
                    else break;
                }
            }

            outputPath = outputPath.Replace(@"\..", "");

            var basePath = "";
            if (prjPathParts != null)
                foreach (var part in prjPathParts)
                {
                    if (part == string.Empty) continue;
                    basePath += part;
                    basePath += sep;
                }

            basePath += outputPath;
            basePath = basePath.Replace(@"\\", @"\");
            if (!basePath.EndsWith(@"\"))
            {
                basePath += @"\";
            }
            return basePath;
        }
    }
}
