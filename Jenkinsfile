
pipeline {
    agent none

    environment {
        DOTNET_CLI_HOME = "C:\\Program Files\\dotnet"
    }

    stages {
        stage('Checkout') {
            agent {
                label 'windows-2'
            }
            steps {
                checkout scm
            }
        }
        
        stage('Stop IIS') {
             agent {
                label 'windows-2'
            }
            steps {
                script {
                    powershell """
                        Stop-Service -Name 'W3SVC' -Force
                        if ((Get-Service 'W3SVC').Status -ne 'Stopped') {
                            Write-Error 'Failed to stop IIS service'
                            exit 1
                        }
                    """
                }
            }
        }
         stage('Build') {
            agent {
                label 'windows-2'
            }
            steps {
                script {
                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
        }     
        
          stage('Publish') {
            agent {
                label 'windows-2'
            }
            steps {
                script {
                    // Publishing the application
                    bat "dotnet publish --configuration Release"
                }
            }
        }
        stage('Checkouts') {
            agent {
                label 'win-slave'
            }
            steps {
                checkout scm
            }
        }

            stage('Stop IIS') {
             agent {
                label 'win-slave'
            }
            steps {
                script {
                    powershell """
                        Stop-Service -Name 'W3SVC' -Force
                        if ((Get-Service 'W3SVC').Status -ne 'Stopped') {
                            Write-Error 'Failed to stop IIS service'
                            exit 1
                        }
                    """
                }
            }
        }
         stage('Builds') {
            agent {
                label 'win-slave'
            }
            steps {
                script {
                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
         }
               
          stage('Publishs') {
            agent {
                label 'win-slave'
            }
            steps {
                script {
                    // Publishing the application
                    bat "dotnet publish --configuration Release"
                }
            }
        }
    
}
}
