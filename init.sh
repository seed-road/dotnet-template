#!/bin/bash
current_directory=$(pwd)
project_name=$(basename "$current_directory")
mv TmpREADME.md README.md
if [[ "$OSTYPE" == "darwin"* ]]; then
  echo "Use bsd sed"
  sed -i '' "s/project_placeholder/$project_name/g" README.md
else
  echo "Use gnu sed"
  sed -i "s/project_placeholder/$project_name/g" README.md  
fi
echo "Create https certificate located at :  ${HOME}/.aspnet/https/$project_name.pfx"
dotnet dev-certs https -ep "${HOME}/.aspnet/https/$project_name.pfx" -p "$project_name.pwd"
dotnet dev-certs https --trust
echo "Create initialize git repository"
git init
git add README.md
git commit -m "first commit"./
git branch -M main
echo "Add common submodule : https://github.com/seed-road/common.git"
git submodule add https://github.com/seed-road/common.git
echo "Set remote GitHub repository : https://github.com/seed-road/$project_name.git"
git remote add origin "https://github.com/seed-road/$project_name.git"
echo "Push first commit to GitHub repository"
git push -u origin main
echo "Remove this script from template"
rm init.sh

