#!/usr/bin/env bash

set -euxo pipefail

cd /tmp

curl -L https://www.nuget.org/api/v2/package/Microsoft.NETFramework.ReferenceAssemblies.net40/1.0.3 -o net4.zip

unzip net4.zip -d net

rm -r "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\Framework\\.NETFramework\\v4.0"

cp -r net/build/.NETFramework/v4.0 "C:\\Program Files (x86)\\Reference Assemblies\\Microsoft\Framework\\.NETFramework\\v4.0"

rm -r net4.zip net
