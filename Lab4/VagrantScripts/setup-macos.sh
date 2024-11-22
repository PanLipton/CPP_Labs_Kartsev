#!/bin/bash

# Install Homebrew if not installed
if ! command -v brew &> /dev/null; then
    /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
fi

# Install .NET SDK
brew install --cask dotnet-sdk

# Clone the repository
git clone https://github.com/PanLipton/CPP_Labs_Kartsev.git /Users/vagrant/CPP_Labs_Kartsev

# Configure NuGet
mkdir -p ~/.nuget/NuGet
cat > ~/.nuget/NuGet/NuGet.Config << EOF
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="BaGet" value="http://192.168.50.10:5000/v3/index.json" />
  </packageSources>
</configuration>
EOF

# Build and install the tool
cd /Users/vagrant/CPP_Labs_Kartsev/Lab4
dotnet build
dotnet pack
dotnet tool install --global IKartsev --add-source ./Lab4/nupkg

# Set up environment
echo 'export PATH="$PATH:/Users/vagrant/.dotnet/tools"' >> ~/.bash_profile
source ~/.bash_profile