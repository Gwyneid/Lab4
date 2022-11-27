// y = x - 2 * cos (0,5 * pi * x) [0.4,0.9]

static double f(double x)
{
    return (x - 2 * Math.Cos(0.5 * Math.PI * x)) ;
}

static double simpson(double a, double b, int n )
{
    double h = (b - a) / n;
    double left;
    double right;
    double integral = 0;
    for (int step = 0; step < n; step++)
    {
        left= a+step*h;
        right= a+(step+1)*h;
        integral += ((right-left)/6)*(f(left)+f(right)+4*f((left+right)/2));
    }
    return (integral) ;
}

double a = 0.4;
double b = 0.9;
double eps = Math.Pow(0.1,8);
double In;
double I2n;
int n = 2;

do
{
    In = simpson(a, b, n);
    I2n = simpson(a, b, 2 * n);
    n *= 2;
} while (Math.Abs(In - I2n) > eps);

Console.WriteLine($"I{n}n={I2n}");