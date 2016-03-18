# DropboxExplorer
The Dropbox Explorer common dialog controls can be used as replacement Open and Save dialogs.

##User Experience
The first screen the user sees is the Dropbox sign in screen. This is customized with your own icon and application name within your Dropbox configuration. All credentials are managed by Dropbox so there is no security risk due to poor management of confidential data.

Once signed in, the dialog looks very similar to the standard Windows dialogs. A familiar toolbar offers Back and Up buttons as well as a crumb-bar that enables a rapid method for returning to a higher level folder.

The dialog optionally provides automatic asynchronous file transfers. Alternatively the file transfer functions are directly exposed so the calling application can manage the transfer in a non-modal way if desired.

##Developers Guide
###Package Installation
Dropbox Explorer can be installed via NuGet from within Visual Studio 2015. Open the Package Manager Console via the Tools \  NuGet Package Manager menu.

Install the DropboxExplorer package using the InstallPackage command
```
PM> Install-Package DropboxExplorer
```
This will install the main Dropbox Explorer package and several dependent packages such as the Dropbox API package and the Newtonsoft Json package.

###Dropbox Explorer Configuration
Before using Dropbox Explorer, you need to create a Dropbox API app. When defining the app, you must define the Redirect URI as ‘https://www.dropbox.com/1/oauth2/redirect_receiver’.

When the app has been created, you will have an App key. This key needs to be given to Dropbox Explorer via the DropboxAppKey property.
```
DropboxExplorer.Configuration.DropboxAppKey = "???????????????";
```
This is a static property so only needs to be set once during the life time of your application.

###Sample Code
Copy one of the following pieces of code into an event handler to show either the Open or Save dialog.

**Open Dialog – Automatic Download**
```
private void btnOpenDialogAutoDownload_Click(object sender, EventArgs e)
{
    using (var dlg = new DropboxExplorer.OpenDropboxDialog())
    {
        // If the DownloadFolder property is configured, 
        // the file will be automatically downloaded to this location
        dlg.DownloadFolder = myDownloadFolder;
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            MessageBox.Show(this, "File downloaded");
        }
    }
}
```

**Open Dialog – Manual Download**
```
private void btnOpenDialogManualDownload_Click(object sender, EventArgs e)
{
    using (var dlg = new DropboxExplorer.OpenDropboxDialog())
    {
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            // The selected file path can be interrogated via the SelectedFile property
            string mySelectedFile = dlg.SelectedFile;
 
            // The file can be downloaded using the DownloadSelectedFile function
            dlg.DownloadSelectedFile(myLocalFilePath);
        }
    }
}
```

**Save Dialog – Automatic Upload**
```
private void btnSaveDialogAutoUpload_Click(object sender, EventArgs e)
{
    using (var dlg = new DropboxExplorer.SaveDropboxDialog())
    {
        // Set the UploadFile property to automatically upload
        // the file to the user specified destination
        dlg.UploadFile = myFileToUpload;
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            MessageBox.Show(this, "File uploaded");
        }
    }
}
```

**Save Dialog – Manual Upload**
```
private void btnSaveDialogManualUpload_Click(object sender, EventArgs e)
{
    using (var dlg = new DropboxExplorer.SaveDropboxDialog())
    {
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            // The destination file path can be interrogated via the SelectedFile property
            string mySelectedFile = dlg.SelectedFile;
 
            // The file can be uploaded using the UploadFileToCurrentFolder function
            dlg.uploadFileToCurrentFolder(myLocalFilePath);
        }
    }
}
```
