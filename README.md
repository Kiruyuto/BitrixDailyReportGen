# BitrixDailyReportGen

### Installation
1. Grab the [latest release](https://github.com/Kiruyuto/BitrixDailyReportGen/releases/latest) from GH or [pack](https://github.com/Kiruyuto/BitrixDailyReportGen/blob/master/.github/workflows/release.yml#L57) the project yourself.
2. Unzip the archive to a folder of your choice.
3. Run the command below in the terminal to install the tool globally.
    ```bash 
    dotnet tool install --global --add-source ./path/to/directory/containing/.nupkg/ BitrixReportGen
    ```
   which in my case translates to:
    ```bash 
    dotnet tool install --global --add-source ~/Desktop/Repos/ BitrixReportGen
   ```
4. Set the `BITRIX_DOMAIN`, `BITRIX_USER_ID` and `BITRIX_API_KEY` environment variables.
5. You can now run the tool from any directory by typing [**bitrixGen**](https://github.com/Kiruyuto/BitrixDailyReportGen/blob/master/BitrixReportGen/BitrixReportGen.csproj#L10) in the terminal.
    ```bash
    bitrixGen # Or bitrixGen.exe
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


# How to get Bitrix24 env vars
### Bitrix Domain
1. Go to main [bitrix page](https://www.bitrix24.net/passport/view/) and copy domain  
  `[unique_domain_id].bitrix24.[domain]` (E.g. `1a2b3c4d.bitrix24.com`)
    <details>
      <summary>Open to see image guide</summary>
    
      ![domain.png](./.github/readme_imgs/domain.png)
      
    </details>


### User Id
1. Go to your B24 domain profile. You can find your user ID in the URL
  `https://[unique_domain_id].bitrix24.[domain]/company/personal/user/[user_id]/`
    <details>
      <summary>Open to see image guide</summary>
    
      ![img.png](./.github/readme_imgs/user-id.png)
      
      > [!IMPORTANT]  
      > You must provide your own user ID. Using someone else's ID will result in unauthorized API calls.
    
    </details>

### API Key
1. Go to (Found it navbar) `Developer resources` -> `Common use cases` -> `Other` ->  `Inbound webhook`
    <details>
      <summary>Open to see image guide</summary>

      ![developer-resources.png](./.github/readme_imgs/developer-resources.png)  
      ![common-use-casees-other.png](./.github/readme_imgs/common-use-cases-other.png)  
      ![inbound-webhook.png](./.github/readme_imgs/inbound-webhook.png)  

    </details>

2. Assign permissions to the webhook
    <details>
      <summary>Open to see image guide</summary>

      ![permissions.png](./.github/readme_imgs/permissions.png)  

   > [!WARNING]  
   > According to API specs, you should only need permissions as shown in the image above.  
   > However, there seems to be a bug where you need more permissions to get the webhook to work.  
   > I wasn't able to determine which permissions are necessary, so I assigned all of them.  
   > ¯\\\_(ツ)\_/¯  
   > ![all-permissions.png](./.github/readme_imgs/all-permissions.png)  

    </details>

3. Click `Generate new` and then copy the key
    <details>
      <summary>Open to see image guide</summary>

      ![api-key.png](./.github/readme_imgs/api-key.png)  

    </details>