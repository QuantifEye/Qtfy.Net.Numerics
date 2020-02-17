# Qtfy.QMath

Qtfy.QMath aims to provide methods and algorithms for mathematical and numerical computations required by other projects in the Qtfy namespace.

Currently Qtfy.QMath is a minimal library that provides the following classes and methods.

## Qtfy.QMath.BigRational

This is a type that is implemented using System.Numerics.BigInteger, and provides the ability to perform arbitrary precision rational computations.

The type also provides static methods that allow BigRational numbers to be rounded to an arbitrary tick size, such as to the nearest third.

## Qtfy.QMath.Combinatorics

The methods in this static class provide the ability to iterate over power sets.

## Qtfy.QMath.SeriesExpansions

The methods in this static class provide the ability calculate the series expansion approximations of the natural logarithm of a BigRational number and the exponent of a BigRational number.

# Building and Testing

## Debug Build
```
git clone git@github.com:QuantifEye/Qtfy.QMath.git
cd Qtfy.QMath
dotnet restore
dotnet build -c Debug
```

## Release Build
```
git clone git@github.com:QuantifEye/Qtfy.QMath.git
cd Qtfy.QMath
dotnet restore
dotnet build -c Release
```

## Run Tests

```
git clone git@github.com:QuantifEye/Qtfy.QMath.git
cd Qtfy.QMath
dotnet restore
dotnet test
```
