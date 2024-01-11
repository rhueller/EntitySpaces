using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows.Forms;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.AddIn.ES2019
{
  public partial class MainWindow : UserControl
  {
    private object _applicationObject;
    private readonly List<esUserControl> _userControlCollection = new List<esUserControl>();
    private esSettings _settings = new esSettings();

    internal OnTemplateExecute OnTemplateExecuteCallback;
    internal OnTemplateCancel OnTemplateCancelCallback;
    internal TemplateDisplaySurface CurrentTemplateDisplaySurface;

    public MainWindow()
    {
      InitializeComponent();

      NotAConstructor();
    }

    private void NotAConstructor()
    {
      try
      {
          if (DesignMode) return;

          TemplateDisplaySurface.Initialize(this);

          Settings = esSettings.Load();
          var plugin = new esPlugIn(_settings);

          ucSettings.Settings = Settings;

          _userControlCollection.Add(ucProjects);
          _userControlCollection.Add(ucTemplates);
          _userControlCollection.Add(ucMetadata);
          _userControlCollection.Add(ucMappings);

          ucProjects.MainWindow = this;
          ucTemplates.MainWindow = this;
          ucMetadata.MainWindow = this;
          ucMappings.MainWindow = this;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
      finally
      {
        _userControlCollection.Add(ucSettings);
        ucSettings.MainWindow = this;
      }
    }

    public object ApplicationObject
    {
      get { return _applicationObject; }
      set { _applicationObject = value; }
    }

    public esSettings Settings
    {
      get { return _settings; }
      set
      {
        _settings = value;
      }
    }

    public void NofityControlsThatSettingsChanged()
    {
      try
      {
        Root.UnLoadPlugins();

        foreach (var control in _userControlCollection)
        {
          control.OnSettingsChanged();
        }
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    public void ShowError(Exception ex)
    {
      try
      {
        var errorText = string.Empty;
        var callStack = string.Empty;

        var cex = ex as CompilerException;

        if (cex != null)
        {
          foreach (CompilerError error in cex.Results.Errors)
          {
            errorText += "Error Found in " + cex.Template.Header.FullFileName + " on line " +
                cex.Template.TemplateLineFromErrorLine(error.Line) +
                Environment.NewLine + error.ErrorText + Environment.NewLine + Environment.NewLine;
          }
        }
        else
        {
          var rootCause = ex;

          while (rootCause.InnerException != null)
          {
            if (rootCause.Equals(ex.InnerException)) break;

            rootCause = ex.InnerException;
          }

          errorText = rootCause.Message;
        }

        splitContainer.Panel2Collapsed = false;
        pictureBoxError.Image = Resource.error;
        textBoxError.Text = errorText;
        textBoxError.Text += Environment.NewLine + Environment.NewLine;
        textBoxError.Text += ex.StackTrace;
        textBoxError.ScrollToCaret();
      }
      catch (Exception exx)
      {
        ShowError(exx);
      }
    }

    public void HideErrorOrStatusMessage()
    {
      try
      {
        splitContainer.Panel2Collapsed = true;
        textBoxError.Text = string.Empty;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    public void ShowStatusMessage(string message)
    {
      splitContainer.Panel2Collapsed = false;
      pictureBoxError.Image = Resource.info;

      textBoxError.Text = message;
      textBoxError.Text += Environment.NewLine + Environment.NewLine;
      textBoxError.ScrollToCaret();
    }

    public void ShowTemplateUIControl()
    {
      try
      {
        splitContainerTabControl.Panel1Collapsed = true;
        splitContainerTabControl.Panel2Collapsed = false;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    private void buttonExecuteTemplateOk_Click(object sender, EventArgs e)
    {
      var origCursor = Cursor;

      try
      {
        if (OnTemplateExecuteCallback == null) return;

        //HideErrorOrStatusMessage();

        Cursor = Cursors.WaitCursor;

        if (!OnTemplateExecuteCallback(CurrentTemplateDisplaySurface)) return;
        
        tabControlTemplateUI.TabPages.Clear();

        splitContainerTabControl.Panel1Collapsed = false;
        splitContainerTabControl.Panel2Collapsed = true;

        OnTemplateExecuteCallback = null;
        OnTemplateCancelCallback = null;
        CurrentTemplateDisplaySurface = null;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
      finally
      {
        Cursor = origCursor;
      }
    }

    private void buttonExecuteTemplateCancel_Click(object sender, EventArgs e)
    {
      try
      {
        if (OnTemplateExecuteCallback == null) return;

        OnTemplateCancelCallback(CurrentTemplateDisplaySurface);

        //HideErrorOrStatusMessage();

        tabControlTemplateUI.TabPages.Clear();

        splitContainerTabControl.Panel1Collapsed = false;
        splitContainerTabControl.Panel2Collapsed = true;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
      finally
      {
        OnTemplateExecuteCallback = null;
        OnTemplateCancelCallback = null;
        CurrentTemplateDisplaySurface = null;
      }
    }

    private void pictureBoxError_Click(object sender, EventArgs e)
    {
      try
      {
        splitContainer.Panel2Collapsed = true;
      }
      catch (Exception ex)
      {
        ShowError(ex);
      }
    }

    private void TabPage_Enter(object sender, EventArgs e)
    {
      try
      {
        HideErrorOrStatusMessage();

        var tabPage = sender as TabPage;

        if (tabPage?.Name != "Projects")
        {
          ucProjects.PromptForSave();
        }
      }
      catch
      {
          // ignored
      }
    }

    internal static ProxySettings GetProxySettings(esSettings settings)
    {
      var proxy = new ProxySettings
      {
          UseProxy = settings.LicenseProxyEnable
      };

      if (!proxy.UseProxy) return proxy;
      
      proxy.Url = settings.LicenseProxyUrl;
      proxy.UserName = settings.LicenseProxyUserName;
      proxy.Password = settings.LicenseProxyPassword;
      proxy.DomainName = settings.LicenseProxyDomainName;

      return proxy;
    }
  }
}
