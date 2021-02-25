#!/usr/bin/env bash

scriptname=$(basename $0)
repo_root="${SYSTEM_DEFAULTWORKINGDIRECTORY:-"$(dirname $0)/.."}"
build_number=${BUILD_BUILDNUMBER:-"0"}
today=$(date +%F)
calculator_test_log_filename="calculator_test_${build_number}_${today}.trx"

function print_and_log {
  message="$@"
  logger "[$scriptname] $message"
  printf "[$scriptname] $message\n"
}

cd $repo_root

dotnet test ./test/CalculatorTests/CalculatorTests.csproj --logger "trx;logfilename=$calculator_test_log_filename"