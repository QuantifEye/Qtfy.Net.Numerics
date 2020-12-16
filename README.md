# Qtfy.Net.Numerics

We are currently working toward version 1.0.0. of the numerics library

# Build
<table>
	<tr>
		 <th colspan="2">Build Status.</th>
 	</tr>
 	<tr>
  		<td>master</td>
      <td><img src="https://travis-ci.com/QuantifEye/Qtfy.Net.Numerics.svg?token=4GppM9ERgowDjXBKpuH5&branch=master" alt=""/></td>
 	</tr>
	<tr>
  		<td>dev</td>
      <td><img src="https://travis-ci.com/QuantifEye/Qtfy.Net.Numerics.svg?token=4GppM9ERgowDjXBKpuH5&branch=dev" alt=""/></td>
 	</tr>
</table>

# Installation
See "add link once released"

# Developement
## Dependencies
See `./global.json` for the required sdk.

## Build
```shell
dotnet build
```
## Unit Testing
```shell
dotnet test
```
## Coverage
This requires two global tools `coverlet.console`, and `dotnet-reportgenerator-globaltool` which can be installed by running the script
`./build/install_global_tools.sh`

To run tests and generate coverage report, run the script `./build/coverage.sh`. This will delete the contents of and recreate the directory `./coverage` and populate the directory with the coverage output.

To view a friendly human readable coverage report, open `./coverage/coverage.cobertura.xml.site.site/index.html` with a internet browser.
