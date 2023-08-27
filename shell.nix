with import <nixpkgs> { };

mkShell {
  name = "dotnet-env";
  buildInputs = [ dotnet-sdk just ];
  shellHook = ''
    # Initialize a local tool manifest if it doesn't exist
    if [ ! -f .config/dotnet-tools.json ]; then
      dotnet new tool-manifest
    fi

    # Install ReportGenerator tool locally if not installed
    if ! dotnet tool list --local | grep -q 'dotnet-reportgenerator-globaltool'; then
      dotnet tool install dotnet-reportgenerator-globaltool --local
    fi
  '';
}
