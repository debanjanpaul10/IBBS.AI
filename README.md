# Introduction

This is an AI Tool that is to be used in combination with Internet Bulletin Board Service. As you know the age of AI is here, with AI technologies booming in the market lately. So why not implement it here as well.

-   This is a secure project that uses Azure PaaS, .NET 9.0 Core, Azure Pipelines and Gemini AI.
-   The Gemini AI can be accessed using the Google AI studio with the API keys.
-   The App secrets, configuration values and other configs are stored securely in the Azure App Configuration.
-   There is a folder called `DeploymentSettings` that will guide you on the keys used and from where it is being picked.

# Getting Started

## Installation Process

-   Make sure you have the .NET 9.0 Core installed in your local machine along with any IDE or Text Editor of your choice.
-   Create a file (if not already exists) called appsettings.development.json. In that file add the two following configs:
    -   `AppConfigurationEndpoint` that will be used to access Azure App Configuration.
    -   `ManagedIdentityClientId` that is the MI client ID that is used to access Azure Resources
-   Once configs are added go to the root of the project and build using `dotnet build`.
-   Once the solution has been built, go to the IBBS.AI.API project and run `dotnet run`.
-   The API will be running at the endpoint mentioned in the Properties/launchSettings.json file.

## Software Dependencies

-   As mentioned previously:
    -   .NET Core 9.x
    -   IDE (Visual Studio 2022 min.)
    -   Text Editor (VSCode, Sublime, etc)

## Branching Strategy

-   There are primarily two branches:
    -   `dev` which is used for development. This branch is locked and for development purposes branches should be created from this branch and PRs to be merged to this branch only.
    -   `main` which is the main branch that will be deployed to production. No direct branches or code to be merged here but only PRs from dev to be accepted here.

## API References

-   The only external API used is the Google Gemini AI API. You can read more about it here
    [Gemini AI API](https://ai.google.dev/gemini-api/docs?_gl=1*sbxb0h*_ga*MTExOTgxNTE4LjE3NDEyNzg4OTA.*_ga_P1DBVKWT6V*MTc0MTcwNDU3NS43LjEuMTc0MTcwNDU5OC4zNy4wLjc4NTc0MTk1Ng..)

# Build and Test

-   As of the latest release and deployment, there is only CI pipeline and on Release pipeline all present in Azure DevOPS.
-   The Build Pipeline is [IBBS.AI.Build](https://dev.azure.com/LTIProjectsDP/MicrosoftIndia/_build?definitionId=4). The definition of this pipeline is in `azure-pipelines.yml` in the solution
    -   This will restore, build, publish and create artifacts stored in the Azure Devops pipeline.
    -   These artifacts will be picked up by the next Release pipeline
    -   Automatic triggers are placed where if PRs are completed in main or dev branch, a new build will be automatically triggered.
-   The Release Pipeline is [IBBS AI Release](https://dev.azure.com/LTIProjectsDP/MicrosoftIndia/_release?_a=releases&view=mine&definitionId=1).
    -   This pipeline will pickup the artifacts and will deploy them to Azure App Service.
    -   The Azure App Service is already connected to this pipeline via ADO using a service connection.
    -   There is an automatic timer trigger for this release pipeline that can be configured later.
    -   New releases are automatically created once an artifact can be found in the ADO. Once the deployment is approved manually only then it is deployed.

# Contribute

Won't be explaining anything here. Try it out for yourself, make changes, test, debug and most important of all : **ENJOY and HAPPY CODING**
