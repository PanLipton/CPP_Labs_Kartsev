#!/bin/bash

# Update and install dependencies
apt-get update
apt-get install -y wget apt-transport-https

# Install .NET SDK
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
apt-get update
apt-get install -y dotnet-sdk-8.0

# Clone your repository
cd /home/vagrant
git clone https://github.com/PanLipton/CPP_Labs_Kartsev.git

# Setup NuGet source
dotnet nuget add source http://localhost:5000/v3/index.json -n "BaGet"

# Install the tool
cd /home/vagrant/project/Lab4
dotnet pack
dotnet tool install --global IKartsev --add-source ./Lab4/nupkg