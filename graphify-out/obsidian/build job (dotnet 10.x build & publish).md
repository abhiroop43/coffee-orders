---
source_file: ".github/workflows/master_coffeeorders.yml"
type: "code"
community: "CI/CD and Deployment"
location: "L13"
tags:
  - graphify/code
  - graphify/EXTRACTED
  - community/CI/CD_and_Deployment
---

# build job (dotnet 10.x build & publish)

## Connections
- [[dot-net-app build artifact]] - `shares_data_with` [EXTRACTED]
- [[Build and deploy ASP.Net Core app to Azure Web App - coffeeorders (workflow)]] - `references` [EXTRACTED]
- [[deploy job (azurewebapps-deploy@v3)]] - `references` [EXTRACTED]

#graphify/code #graphify/EXTRACTED #community/CI/CD_and_Deployment