# BitrixDailyReportGen

### Installation
1. Grab the [latest release](https://github.com/Kiruyuto/BitrixDailyReportGen/releases/latest) from GH or compile the project yourself.
2. Unzip the archive to a folder of your choice.
3. Run the command below in the terminal to install the tool globally.
    ```bash 
    dotnet tool install --global --add-source ./path/to/directory/containing/.nupkg/ BitrixReportGen
    ```
   which in my case translates to:
    ```bash 
    dotnet tool install --global --add-source ./artifacts/ BitrixReportGen
   ```
4. You can now run the tool from any directory by typing [**bitrixGen**](https://github.com/Kiruyuto/BitrixDailyReportGen/blob/master/BitrixReportGen/BitrixReportGen.csproj#L10) in the terminal.
    ```
    bitrixGen
    ```