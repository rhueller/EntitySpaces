using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

using EnvDTE;
using EnvDTE80;
using Extensibility;

using Microsoft.VisualStudio.CommandBars;

namespace EntitySpaces.AddIn.ES2019
{
#if (!StandAlone)
    /// <summary>The object for implementing an Add-in.</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        private Window toolWindow;
        private MainWindow esWindow;
        private bool menuRegistered = false;

        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        public Connect()
        {

        }

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param term='application'>Root object of the host application.</param>
        /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param term='addInInst'>Object representing this Add-in.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            try
            {
                _applicationObject = (DTE2)application;
                _addInInstance = (EnvDTE.AddIn)addInInst;

                if (!menuRegistered)
                {
                    Commands2 commands = (Commands2)_applicationObject.Commands;

                    foreach (Command cmd in commands)
                    {
                        if (cmd.Name == "EntitySpaces.AddIn.ES2019.Connect.EntitySpaces2019")
                        {
                            menuRegistered = true;
                            break;
                        }
                    }

                    if (!menuRegistered)
                    {
                        try
                        {
                            string toolsMenuName = "";

                            try
                            {
                                //If you would like to move the command to a different menu, change the word "Tools" to the 
                                //  English version of the menu. This code will take the culture, append on the name of the menu
                                //  then add the command to that menu. You can find a list of all the top-level menus in the file
                                //  CommandBar.resx.
                                string resourceName;
                                ResourceManager resourceManager = new ResourceManager("EntitySpaces.AddIn.ES2019.CommandBar", Assembly.GetExecutingAssembly());
                                CultureInfo cultureInfo = new CultureInfo(_applicationObject.LocaleID);

                                if (cultureInfo.TwoLetterISOLanguageName == "zh")
                                {
                                    System.Globalization.CultureInfo parentCultureInfo = cultureInfo.Parent;
                                    resourceName = string.Concat(parentCultureInfo.Name, "Tools");
                                }
                                else
                                {
                                    resourceName = string.Concat(cultureInfo.TwoLetterISOLanguageName, "Tools");
                                }
                                toolsMenuName = resourceManager.GetString(resourceName);
                            }
                            catch
                            {
                                //We tried to find a localized version of the word Tools, but one was not found.
                                //  Default to the en-US word, which may work for the current culture.
                                toolsMenuName = "Tools";
                            }

                            //Place the command on the tools menu.
                            //Find the MenuBar command bar, which is the top-level command bar holding all the main menu items:
                            Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];

                            //Find the Tools command bar on the MenuBar command bar:
                            CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
                            CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;

                            object[] contextGUIDS = new object[] { };

                            Command command = commands.AddNamedCommand2(_addInInstance, "EntitySpaces2019", "EntitySpaces 2019", "Open the EntitySpaces 2019 Window", true, 1018,
                                ref contextGUIDS, (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled,
                                (int)vsCommandStyle.vsCommandStylePictAndText, vsCommandControlType.vsCommandControlTypeButton);

                            //Add a control for the command to the tools menu:
                            if ((command != null) && (toolsPopup != null))
                            {
                                command.AddControl(toolsPopup.CommandBar, 1);
                                menuRegistered = true;
                            }
                        }
                        catch (System.ArgumentException eee)
                        {
                           
                        }
                    }
                }

                if (esWindow == null)
                {
                    object programmableObject = null;

                    string guidString = "{08C42F7C-B8FB-4c8b-B364-37F7E04E78E7}";
                    Windows2 windows2 = (Windows2)_applicationObject.Windows;
                    Assembly asm = Assembly.GetExecutingAssembly();
                    toolWindow = windows2.CreateToolWindow2(_addInInstance, asm.Location, "EntitySpaces.AddIn.ES2019.MainWindow", "EntitySpaces 2019",
                        guidString, ref programmableObject);
                    toolWindow.Visible = true;
                    esWindow = (MainWindow)toolWindow.Object;
                    esWindow.ApplicationObject = _applicationObject;
                }
            }
            catch { }
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param term='commandName'>The name of the command to determine state for.</param>
        /// <param term='neededText'>Text that is needed for the command.</param>
        /// <param term='status'>The state of the command in the user interface.</param>
        /// <param term='commandText'>Text requested by the neededText parameter.</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            try
            {
                if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
                {
                    if (commandName == "EntitySpaces.AddIn.ES2019.Connect.EntitySpaces2019")
                    {
                        status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                        return;
                    }
                }
            }
            catch { }
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param term='commandName'>The name of the command to execute.</param>
        /// <param term='executeOption'>Describes how the command should be run.</param>
        /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
        /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
        /// <param term='handled'>Informs the caller if the command was handled or not.</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            try
            {
                handled = false;
                if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
                {
                    if (commandName == "EntitySpaces.AddIn.ES2019.Connect.EntitySpaces2019")
                    {
                        toolWindow.Visible = true;
                        handled = true;
                        return;
                    }
                }
            }
            catch { }
        }

        private DTE2 _applicationObject;
        private EnvDTE.AddIn _addInInstance;
    }
#endif
}