#!/usr/bin/env bash

scriptname=$(basename $0)
scriptpath=$(realpath $0)
repo_root="${SYSTEM_DEFAULTWORKINGDIRECTORY:-"$(dirname ${scriptpath%/*})"}"

function print_and_log {
  message="$@"
  logger "[$scriptname] $message"
  printf "[$scriptname] $message\n"
}

pushd $repo_root

print_and_log "dotnet build with Release config"

# builds
dotnet build ./src/Calculator/Calculator.csproj -c Release
dotnet build ./src/CalcWeb/CalcWeb.csproj -c Release
dotnet build ./src/Calculator.Data/Calculator.Data.csproj -c Release

dotnet build ./test/calculatorTests/calculatorTests.csproj -c Release
dotnet build ./test/CalcWebTests/CalcWebTests.csproj -c Release
dotnet build ./test/Calculator.Data.Tests/Calculator.Data.Tests.csproj -c Release