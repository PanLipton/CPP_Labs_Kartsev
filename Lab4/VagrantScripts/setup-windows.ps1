Set-ExecutionPolicy Bypass -Scope Process -Force
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

choco install dotnet-sdk -y

cd C:\
git clone https://github.com/PanLipton/CPP_Labs_Kartsev.git

dotnet nuget add source http://localhost:5000/v3/index.json -n "BaGet"

cd C:\vagrant\project\Lab4
dotnet pack
dotnet tool install --global IKartsev --add-source ./Lab4/nupkg