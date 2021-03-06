namespace Qtfy.Net.Numerics
{
    public interface IContiniousDistribution : IDistribution<double>
    {
        /// <summary>
        /// Calculates the probability density function at <paramref name="x"/>.
        /// </summary>
        /// <param name="x">
        /// The value at which to evaluate the probability mass function.
        /// </param>
        /// <returns>
        /// The probability density function at <paramref name="x"/>.
        /// </returns>
        double Density(double x);

        /// <summary>
        /// Calculates natural logarithm of the probability density function at <paramref name="x"/>.
        /// </summary>
        /// <param name="x">
        /// The value at which to evaluate the function.
        /// </param>
        /// <returns>
        /// The log of the probability density function evaluated at <paramref name="x"/>.
        /// </returns>
        double DensityLn(double x);
    }
}
