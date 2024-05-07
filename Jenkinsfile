pipeline {
      agent {
        // Define the agent where the pipeline will run
        label 'win-slave'
    }

    environment {
        DOTNET_CLI_HOME = "C:\\Program Files\\dotnet"
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
     
        stage('SonarQube Analysis') {
              steps {
                def scannerHome = tool 'SonarScanner for MSBuild'
                withSonarQubeEnv() {
                bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll begin /k:\"Dotnetpro\""
                bat "dotnet build"
                bat "dotnet ${scannerHome}\\SonarScanner.MSBuild.dll end"
              }
          }
          
        stage('Build') {
            steps {
                script {
                    // Restoring dependencies
                    //bat "cd ${DOTNET_CLI_HOME} && dotnet restore"
                    bat "dotnet restore"

                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    // Running tests
                    bat "dotnet test --no-restore --configuration Release"
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    // Publishing the application
                    bat "dotnet publish --no-restore --configuration Release --output .\\publish"
                }
            }
        }
    }

    post {
        success {
            echo 'Build, test, and publish successful!'
        }
    }
}
