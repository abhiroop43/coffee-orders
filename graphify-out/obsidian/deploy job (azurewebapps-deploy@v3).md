---
source_file: ".github/workflows/master_coffeeorders.yml"
type: "code"
community: "CI/CD and Deployment"
location: "L38"
tags:
  - graphify/code
  - graphify/EXTRACTED
  - community/CI/CD_and_Deployment
---

# deploy job (azure/webapps-deploy@v3)

## Connections
- [[dot-net-app build artifact]] - `shares_data_with` [EXTRACTED]
- [[Azure Web App 'coffeeorders' (Production slot)]] - `references` [EXTRACTED]
- [[Build and deploy ASP.Net Core app to Azure Web App - coffeeorders (workflow)]] - `references` [EXTRACTED]
- [[build job (dotnet 10.x build & publish)]] - `references` [EXTRACTED]

#graphify/code #graphify/EXTRACTED #community/CI/CD_and_Deployment