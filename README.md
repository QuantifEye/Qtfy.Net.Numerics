Welcome to the QuantifEye Numerics repository.

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

We are currently on version 1.0.0. consist of an arbitrary precision Rational Number, and related series expansions to calculate `Exp` and `Log`.



Serialization support has not been added but is planned. More to come.

# Installation
see [nuget](https://www.nuget.org/packages/Qtfy.Net.ExampleNugetRepository/).

# Developement
The current required dotnet sdk is version 5.0.1xx.

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
