---
type: community
members: 8
---

# CI/CD and Deployment

**Members:** 8 nodes

## Members
- [[dot-net-app build artifact]] - concept - .github/workflows/master_coffeeorders.yml
- [[Azure Web App 'coffeeorders' (Production slot)]] - concept - .github/workflows/master_coffeeorders.yml
- [[Build and deploy ASP.Net Core app to Azure Web App - coffeeorders (workflow)]] - code - .github/workflows/master_coffeeorders.yml
- [[Docker Compose configuration]] - code - compose.yaml
- [[build job (dotnet 10.x build & publish)]] - code - .github/workflows/master_coffeeorders.yml
- [[coffeeorders.api compose service]] - code - compose.yaml
- [[deploy job (azurewebapps-deploy@v3)]] - code - .github/workflows/master_coffeeorders.yml
- [[srcCoffeeOrders.ApiDockerfile]] - code - compose.yaml

## Live Query (requires Dataview plugin)

```dataview
TABLE source_file, type FROM #community/CI/CD_and_Deployment
SORT file.name ASC
```
