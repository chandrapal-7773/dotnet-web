
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
         stage('Build') {
            agent {
                label 'windows-2'
            }
            steps {
                script {
                    // Restoring dependencies
                    bat "dotnet restore"

                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
        }
        
         stage('Test') {
            agent {
                label 'windows-2'
            }
            steps {
                script {
                    // Running tests
                    bat "dotnet test --no-restore --configuration Release"
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

    stages {
        stage('Checkout') {
            agent {
                label 'win-slave'
            }
            steps {
                checkout scm
            }
        }
         stage('Build') {
            agent {
                label 'win-slave'
            }
            steps {
                script {
                    // Restoring dependencies
                    bat "dotnet restore"

                    // Building the application
                    bat "dotnet build --configuration Release"
                }
            }
        }
        
         stage('Test') {
            agent {
                label 'win-slave'
            }
            steps {
                script {
                    // Running tests
                    bat "dotnet test --no-restore --configuration Release"
                }
            }
        }
        
        
          stage('Publish') {
            agent {
                label 'win-slave'
            }
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
