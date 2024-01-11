using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using EntitySpaces.AddIn.TemplateUI;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

using EntitySpaces.AddIn.ES2019;

namespace EntitySpaces.AddIn
{
    internal delegate bool OnTemplateExecute(TemplateDisplaySurface surface);
    internal delegate void OnTemplateCancel(TemplateDisplaySurface surface);

    internal class TemplateDisplaySurface
    {
        private static readonly TemplateUICollection Coll = new TemplateUICollection();
        private static MainWindow _mainWindow;

        private static Dictionary<Guid, Hashtable> _cachedInput = new Dictionary<Guid, Hashtable>();
        private readonly SortedList<int, UserControl> _currentUiControls = new SortedList<int, UserControl>();
        public Root EsMeta;
        public Template Template;


        internal static void Initialize(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void DisplayTemplateUi
        (
            bool useCachedInput, 
            Hashtable input,
            esSettings settings,
            Template template, 
            OnTemplateExecute onExecuteCallback, 
            OnTemplateCancel onCancelCallback
        )
        {
            try
            {
                Template = template;

                _mainWindow.OnTemplateExecuteCallback = onExecuteCallback;
                _mainWindow.OnTemplateCancelCallback = onCancelCallback;
                _mainWindow.CurrentTemplateDisplaySurface = this;

                if (template != null)
                {
                    _currentUiControls.Clear();
                    PopulateTemplateInfoCollection();

                    var templateInfoCollection = Coll.GetTemplateUI(template.Header.UserInterfaceID);

                    if (templateInfoCollection == null || templateInfoCollection.Count == 0)
                    {
                        _mainWindow.ShowError(new Exception("Template UI Assembly Cannot Be Located"));
                    }

                    EsMeta = esMetaCreator.Create(settings);

                    EsMeta.Input["OutputPath"] = settings.OutputPath;

                    if (useCachedInput)
                    {
                        if (_cachedInput.TryGetValue(template.Header.UniqueID, out var cachedInput))
                        {
                            if (cachedInput != null)
                            {
                                foreach (string key in cachedInput.Keys)
                                {
                                    EsMeta.Input[key] = cachedInput[key];
                                }
                            }
                        }
                    }

                    if (input != null)
                    {
                        EsMeta.Input = input;
                    }

                    _mainWindow.tabControlTemplateUI.SuspendLayout();

                    if (templateInfoCollection?.Values != null)
                        foreach (var info in templateInfoCollection.Values)
                        {
                            var userControl = info.UserInterface.CreateInstance(EsMeta, useCachedInput,
                                _mainWindow.ApplicationObject);
                            _currentUiControls.Add(info.TabOrder, userControl);

                            var page = new TabPage(info.TabTitle);
                            page.Controls.Add(userControl);

                            userControl.Dock = DockStyle.Fill;

                            _mainWindow.tabControlTemplateUI.TabPages.Add(page);

                            _mainWindow.ShowTemplateUIControl();
                        }

                    _mainWindow.tabControlTemplateUI.ResumeLayout();

                    if (_currentUiControls.Count > 0)
                    {
                        _mainWindow.ShowTemplateUIControl();
                    }
                }
            }
            catch (Exception ex)
            {
                _mainWindow.ShowError(ex);
            }
        }

        private void PopulateTemplateInfoCollection()
        {
            try
            {
                if (!Coll.IsLoaded)
                {
                    Coll.RegisterAssemblies(_mainWindow.Settings.UIAssemblyPath);
                }
            }
            catch (Exception ex)
            {
                _mainWindow.ShowError(ex);
            }
        }

        public bool GatherUserInput()
        {
            try
            {
                foreach (var userControl in _currentUiControls.Values)
                {
                    if (userControl is ITemplateUI templateUi && !templateUi.OnExecute())
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                _mainWindow.ShowError(ex);
            }

            return true;
        }

        public Hashtable CacheUserInput()
        {
            var settings = (Hashtable)EsMeta.Input.Clone();
            _cachedInput[Template.Header.UniqueID] = settings;
            return settings;
        }

        public static void ClearCachedSettings()
        {
            _cachedInput = new Dictionary<Guid, Hashtable>();
        }
    }
}
