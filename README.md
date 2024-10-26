# BitrixDailyReportGen

### Installation
1. Grab the [latest release](https://github.com/Kiruyuto/BitrixDailyReportGen/releases/latest) from GH or [pack](https://github.com/Kiruyuto/BitrixDailyReportGen/blob/master/.github/workflows/release.yml#L47) the project yourself.
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
   
<details>
<summary>Example of generated content</summary>

```text
# Daily report for 26.10.2024, created at 13:51:48 #

### [Project #1] => 0h 1m 1s ###
- ExampleTask_1 => 0h 1m 0s
- ExampleTask_2 => 0h 0m 1s

Total time spent today across all projects: [0h 1m 1s]


```

</details>