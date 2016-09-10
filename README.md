XBuild.XmlTransform
===========
Provides <TransformXml/> tasks for xbuild as described here: https://mzabani.wordpress.com/2013/09/24/mono-asp-net-project-deployment-with-web-config-xdt-transformations/.

### Usage

1. To install XBuild.XmlTransform, run the following command in the Package Manager Console
```
Install-Package XBuild.XmlTransform 
```

2. Add `UsingTask` element in MSBuild scripts, you should modify the path of `XBuild.XmlTransform.dll`.
```
<?xml version="1.0" encoding="utf-8"?>

<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">

    <UsingTask TaskName="TransformXml" AssemblyFile="..\..\XBuild.XmlTransform.1.0.0\tools\XBuild.XmlTransform.dll" />

    <Target Name="TransformAppConfig" AfterTargets="Build">
        
        <TransformXml Source="App.config" Transform="App.$(Configuration).config"
                      Destination="@(AppConfigWithTargetPath->'$(OutDir)%(TargetPath)')" />
    
    </Target>
    
</Project>
```

