/*
 * @(#)MathFunctions.cs        2.1.1    2016-01-03
 * 
 * You may use this software under the condition of "Simplified BSD License"
 * 
 * Copyright 2010-2015 MARIUSZ GROMADA. All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 * 
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 * 
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY <MARIUSZ GROMADA> ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of MARIUSZ GROMADA.
 * 
 * If you have any questions/bugs feel free to contact:
 * 
 *     Mariusz Gromada
 *     mariusz.gromada@mathspace.pl
 *     http://mathspace.pl/
 *     http://mathparser.org/
 *     http://github.com/mariuszgromada/MathParser.org-mXparser
 *     http://mariuszgromada.github.io/MathParser.org-mXparser/
 *     http://mxparser.sourceforge.net/
 * 
 *                              Asked if he believes in one God, a mathematician answered: 
 *                              "Yes, up to isomorphism."  
 */

using System;

namespace org.mariuszgromada.math.mxparser.mathcollection {

    /**
     * MathFunctions - the most popular math functions. Many of function implemented by this class
     * could be found in java Math package (in fact functions from MathFunctions typically calls
     * original functions from the Math package). The reason why it was "re-implemented" is:
     * if you decide to implement your own function you do not need to change anything in the parser,
     * jut modify function implementation in this class.  
     * 
     * @author         <b>Mariusz Gromada</b><br/>
     *                 <a href="mailto:mariusz.gromada@mathspace.pl">mariusz.gromada@mathspace.pl</a><br>
     *                 <a href="http://mathspace.pl/">http://mathspace.pl/</a><br>
     *                 <a href="http://mxparser.sourceforge.net/">http://mxparser.sourceforge.net/</a><br>
     *                         
     * @version        2.1.1
     */
    [CLSCompliant(true)]
    public sealed class MathFunctions {

	    /**
	     * Bell Numbers
	     * 
	     * @param      n                   the n
	     * 
	     * @return     if n >= 0 returns Bell numbers,
	     *             otherwise returns Double.NaN.
	     */
	    public static double bellNumber(int n) {
    		
		    double result = Double.NaN;

		    if (n > 1) {
    			
			    n -= 1;
    			
			    long[,] bellTriangle = new long[n+1, n+1];
			    bellTriangle[0, 0] = 1;
			    bellTriangle[1, 0] = 1;
    			
			    for (int r = 1; r <= n; r++) {
				    for (int k = 0; k < r; k++)
					    bellTriangle[r, k+1] = bellTriangle[r-1, k] + bellTriangle[r, k];
    				
				    if (r < n)
					    bellTriangle[r+1, 0] = bellTriangle[r, r];
    				
			    }
    			
			    result = bellTriangle[n, n];
    			
		    } else if (n >= 0)
			    result = 1;
    		
		    return result;
    		
    		
	    }

    	
	    /**
	     * Bell number
	     * @param      n                   the n
	     * 
	     * @return     if n <> Double.NaN return bellNumber( (int)Math.round(n) ),
	     *             otherwise return Double.NaN.
	     */
	    public static double bellNumber(double n) {
    				
		    if (Double.IsNaN(n))
			    return Double.NaN;
    		
		    return bellNumber( (int)Math.Round(n) );
    		
    		
	    }	
    	
	    /**
	     * Euler numbers
	     * 
	     * @param      n                   the n function param
	     * @param      k                   the k function param
	     * 
	     * @return     if n >=0 returns Euler number,
	     *             otherwise return Double.NaN.
	     */
	    public static double eulerNumber(int n, int k) {	
    				
    		
		    if ( n < 0)
			    return Double.NaN;
    		
		    if (k < 0)
			    return 0;
    		
		    if (n == 0)
			    if (k == 0)
				    return 1;
			    else
				    return 0;
    		
		    return (k+1) * eulerNumber(n-1, k) + (n-k) * eulerNumber(n-1, k-1);		
    		
	    }
    	
	    /**
	     * Euler numbers
	     * 
	     * @param      n                   the n function param
	     * @param      k                   the k function param
	     * 
	     * @return     if n, k <> Double.NaN returns eulerNumber( (int)Math.round(n), (int)Math.round(k) ),
	     *             otherwise return Double.NaN.
	     */	
	    public static double eulerNumber(double n, double k) {	
    				
		    if (Double.IsNaN(n) || Double.IsNaN(k))
			    return Double.NaN;
    				
		    return eulerNumber( (int)Math.Round(n), (int)Math.Round(k) );
    		
	    }	
    	
	    /**
	     * Factorial
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     Factorial if n >=0, otherwise returns Double.NaN.
	     */
	    public static double factorial(int n) {		
    		
		    double f = Double.NaN;
    		
		    if (n >= 0)
			    if (n < 2) f = 1;
			    else {
    				
				    f = 1;
    				
				    for (int i = 1; i <= n; i++)
					    f = f*i;
			    }
    		
		    return f;

	    }
    	
    	
	    /**
	     * Factorial
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n <> Double.NaN return factorial( (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double factorial(double n) {
    		
		    if (Double.IsNaN(n))
			    return Double.NaN;		
    		
		    return factorial( (int)Math.Round(n) );

	    }	
    	
	    /**
	     * Generalized binomial coefficient
	     * 
	     * @param      n                   the n function parameter
	     * @param k    k                   the k function parameter
	     * 
	     * @return     Generalized binomial coefficient, if
	     *             n = Double.NaN or k<0 returns Double.NaN.
	     */
	    public static double binomCoeff(double n, int k) {
    			
		    if (Double.IsNaN(n))
			    return Double.NaN;

    		
		    double result = Double.NaN;
    		
		    if ( k >= 0 ){
    			
			    double numerator = 1;
    						
			    if (k > 0 )
				    for (int i = 0; i <= k-1; i++)
					    numerator*=(n-i);
    			
			    double denominator = 1;
    			
			    if ( k > 1 )
			    for (int i = 1; i <= k; i++)
				    denominator *= i;
    			
			    result = numerator / denominator;
    			
		    }
    		
		    return result;
    	
	    }	
    	
	    /**
	     * Generalized binomial coefficient
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     if n, k <> Double.NaN returns binomCoeff(n, (int)Math.round(k) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double binomCoeff(double n, double k) {
    		
		    if (Double.IsNaN(n) || Double.IsNaN(k))
			    return Double.NaN;		
    		
		    return binomCoeff(n, (int)Math.Round(k) );
    		
	    }
    	
    	
	    /**
	     * Bernoulli numbers
	     *  
	     * @param      m                   the m function parameter
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n, m >= 0 returns Bernoulli number,
	     *             otherwise returns Double.NaN.
	     */
	    public static double bernoulliNumber(int m, int n) {
    		
		    double result = Double.NaN;
    		
    		
		    if ( (m >= 0) && (n >= 0) ) {
    			
			    result = 0;
    			
			    for (int k = 0; k <= m; k++)
				    for (int v = 0; v <= k; v++)
					    result += Math.Pow(-1, v) * binomCoeff(k, v)
						    * ( Math.Pow(n + v, m) / (k + 1) )
						    ;
		    }
    		
		    return result;
    		
	    }
    	
	    /**
	     * Bernoulli numbers
	     *  
	     * @param      m                   the m function parameter
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n, m <> Double.NaN returns bernoulliNumber( (int)Math.round(m), (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double bernoulliNumber(double m, double n) {
    		
		    if (Double.IsNaN(m) || Double.IsNaN(n))
			    return Double.NaN;
    		
		    return bernoulliNumber( (int)Math.Round(m), (int)Math.Round(n) );
    		
	    }
    	
	    /**
	     * Striling numbers of the first kind
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     Striling numbers of the first kind
	     */
	    public static double Srirling1Number(int n, int k) {
    		
		    if (k > n)
			    return 0;

		    if (n == 0)
			    if (k == 0)
				    return 1;
			    else
				    return 0;

		    if (k == 0)
			    if (n == 0)
				    return 1;
			    else
				    return 0;
    		
		    return (n-1) * Srirling1Number(n-1, k) + Srirling1Number(n-1, k-1);
    		
    		
	    }

	    /**
	     * Striling numbers of the first kind
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     if n, k <> Doube.NaN returns Srirling1Number( (int)Math.round(n), (int)Math.round(k) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double Srirling1Number(double n, double k) {
    		
		    if (Double.IsNaN(n) || Double.IsNaN(k))
			    return Double.NaN;
    		
		    return Srirling1Number( (int)Math.Round(n), (int)Math.Round(k) );
    		
	    }	
    	
	    /**
	     * Striling numbers of the second kind
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     Striling numbers of the second kind
	     */
	    public static double Srirling2Number(int n, int k) {
    		
    		
		    if (k > n)
			    return 0;

		    if (n == 0)
			    if (k == 0)
				    return 1;
			    else
				    return 0;

		    if (k == 0)
			    if (n == 0)
				    return 1;
			    else
				    return 0;
    		
		    return k * Srirling2Number(n-1, k) + Srirling2Number(n-1, k-1);
    				
	    }


	    /**
	     * Striling numbers of the second kind
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     if n, k <> Doube.NaN returns Srirling2Number( (int)Math.round(n), (int)Math.round(k) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double Srirling2Number(double n, double k) {		
    		
		    if (Double.IsNaN(n) || Double.IsNaN(k))
			    return Double.NaN;
    		
		    return Srirling2Number( (int)Math.Round(n), (int)Math.Round(k) );
    		
	    }	
    	
	    /**
	     * Worpitzky numbers
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     if n,k>=0 and k<=n return Worpitzky number,
	     *             otherwise return Double.NaN.
	     */
	    public static double worpitzkyNumber(int n, int k) {
    		
		    double result = Double.NaN;
    		
		    if ( (n >= 0) && (k >= 0) && (k <= n) ){
    			
			    result = 0;
    			
			    for (int v = 0; v <= k; v++)
				    result += Math.Pow(-1, v+k) * Math.Pow(v+1, n) * binomCoeff(k, v);
    						
		    }
    		
    		
		    return result;		
    		
	    }


	    /**
	     * Worpitzky numbers
	     * 
	     * @param      n                   the n function parameter
	     * @param      k                   the k function parameter
	     * 
	     * @return     if n,k<> Double.NaN returns worpitzkyNumber( (int)Math.round(n), (int)Math.round(k) ),
	     *             otherwise return Double.NaN.
	     */
	    public static double worpitzkyNumber(double n, double k) {		
    		
		    if (Double.IsNaN(n) || Double.IsNaN(k))
			    return Double.NaN;
    		
		    return worpitzkyNumber( (int)Math.Round(n), (int)Math.Round(k) );		
    		
	    }
    	
	    /**
	     * Harmonic numer
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n>0 returns harmonic number, otherwise returns 0
	     *             (empty summation operator)
	     */
	    public static double harmonicNumber(int n) {
    				
		    if (n <= 0)
			    return 0;
    		
		    if (n == 1)
			    return 1;
    		
		    double h = 1;

		    for (double k = 2.0; k <= n; k++)
			    h += 1.0 / k;
    		
		    return h;
    		
	    }	
    	
	    /**
	     * Harmonic number
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n <> Double.NaN returns harmonicNumber( (int)Math.round(n) ),
	     *             otherwise returns Double.NaN
	     */
	    public static double harmonicNumber(double n) {

		    if (Double.IsNaN(n))
			    return Double.NaN;
    		
		    return harmonicNumber( (int)Math.Round(n) );
    		
	    }
    	
	    /**
	     * Harmonic number 1/1 + 1/2^x + ... + 1/n^x
	     * 
	     * @param      x                   the x function parameter
	     * @param      n                   the n function parameter
	     * 
	     * @return     if x<> Double.NaN and x>=0 Harmonic number,
	     *             otherwise returns Double.NaN.
	     */
	    public static double harmonicNumber(double x, int n) {

		    if  ( (Double.IsNaN(x)) || (x < 0) )
			    return Double.NaN;		
    		
		    if (n <= 0)
			    return 0;
    		
		    if (n == 1)
			    return x;
    		
		    double h = 1;

		    for (double k = 2.0; k <= n; k++)
			    h += 1 / power(k, x);
    		
		    return h;
    		
	    }
    	
	    /**
	     * Harmonic number 1/1 + 1/2^x + ... + 1/n^x
	     * 
	     * @param      x                   the x function parameter
	     * @param      n                   the n function parameter
	     * 
	     * @return     if x,n <> Double.NaN returns harmonicNumber( x, (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double harmonicNumber(double x, double n) {

		    if ( (Double.IsNaN(x)) || (Double.IsNaN(n)) )
			    return Double.NaN;
    		
		    return harmonicNumber( x, (int)Math.Round(n) );
    		
	    }
    	
    	
	    /**
	     * Catalan numbers
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     Catalan numbers
	     */
	    public static double catalanNumber(int n) {
    				
		    return binomCoeff(2*n, n) * div(1, n+1);
    		
	    }
    	
	    /**
	     * Catalan numbers
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n <> Double.NaN returns catalanNumber( (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double catalanNumber(double n) {
    		
		    if (Double.IsNaN(n))
			    return Double.NaN;
    		
		    return catalanNumber( (int)Math.Round(n) );
    		
	    }
    	
	    /**
	     * Fibonacci numbers
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n >= 0 returns fibonacci numbers,
	     *             otherwise returns Double.NaN.
	     */	
	    public static double fibonacciNumber(int n) {
    		
		    if (n < 0 )
			    return Double.NaN;
    		
		    if (n == 0)
			    return 0;
    		
		    if (n == 1)
			    return 1;
    		
    		
		    return fibonacciNumber(n-1) + fibonacciNumber(n-2);
    		
	    }

	    /**
	     * Fibonacci numbers
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n <> Double.NaN returns fibonacciNumber( (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double fibonacciNumber(double n) {
    				
		    if (Double.IsNaN(n))
			    return Double.NaN;
    		
		    return fibonacciNumber( (int)Math.Round(n) );
    		
	    }
    	
	    /**
	     * Lucas numebrs
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n >=0 returns Lucas numbers,
	     *             otherwise returns Double.NaN.
	     */
	    public static double lucasNumber(int n) {
    		
		    if (n < 0 )
			    return Double.NaN;
    		
		    if (n == 0)
			    return 2;
    		
		    if (n == 1)
			    return 1;
    		
    		
		    return lucasNumber(n-1) + lucasNumber(n-2);
    		
	    }	
    	
	    /**
	     * Lucas numebrs
	     * 
	     * @param      n                   the n function parameter
	     * 
	     * @return     if n <> Double.NaN returns lucasNumber( (int)Math.round(n) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double lucasNumber(double n) {
    		
		    if (Double.IsNaN(n))
			    return Double.NaN;
    		
		    return lucasNumber( (int)Math.Round(n) );
    		
	    }
    	
	    /**
	     * Kronecker delta
	     * 
	     * @param      i                   the i function parameter
	     * @param      j                   the j function parameter
	     * 
	     * @return     if i,j <> Double.NaN returns Kronecker delta,
	     *             otherwise returns Double.NaN.
	     */
	    public static double kroneckerDelta(double i, double j) {
    		
		    if (Double.IsNaN(i) || Double.IsNaN(j))
			    return Double.NaN;
    		
		    if (i == j)
			    return 1;
		    else
			    return 0;
    		
	    }
    	
	    /**
	     * Kronecker delta
	     * 
	     * @param      i                   the i function parameter
	     * @param      j                   the j function parameter
	     * 
	     * @return     Kronecker delta
	     */
	    public static double kroneckerDelta(int i, int j) {
    		
		    if (i == j)
			    return 1;
		    else
			    return 0;
    		
	    }
    	
	    /**
	     * Continued fraction
	     * 
	     * @param      sequence            the numbers
	     * 
	     * @return     if each number form the sequence <> Double.NaN and
	     *             there is no division by 0 while computing returns continued fraction
	     *             value, otherwise returns Double.NaN.
	     */
	    public static double continuedFraction(params double[] sequence) {

		    double cf = 0;
		    double a;

		    if (sequence.Length == 1)
			    return sequence[0];
    		
		    int lastIndex = sequence.Length-1;
    		
		    for(int i = lastIndex; i >= 0; i--) {
    			
			    a = sequence[i];
    			
			    if (Double.IsNaN(a))
				    return Double.NaN;
    			
			    if (i == lastIndex) {
    							
				    cf = a;
    				
			    } else {
    				
				    if (cf == 0)
					    return Double.NaN;
    				
				    cf = a + 1.0 / cf; 
    				

			    }
    						
		    }
    		
    		
		    return cf;
    		
	    }
    	
    	

	    /**
	     * Private function calculating continued polynomial
	     * recursively.
	     * 
	     * @param      n         the polunomial order
	     * @param      x         the x values
	     *  
	     * @return     continued polynomial value
	     */
	    private static double continuedPolynomial(int n, double[] x) {
    		
		    if (n == 0)
			    return 1;
    		
		    if (n == 1)
			    return x[0];
    		
		    return x[n-1] * continuedPolynomial(n-1, x) + continuedPolynomial(n-2, x);
    		
	    }
    	
    	
	    /**
	     * Continued polynomial
	     * 
	     * @param      x         the x values
	     * 
	     * @return     if each number for x is different the Double.NaN
	     *             returns continued polynomial, otherwise returns
	     *             Double.NaN.
	     */
	    public static double continuedPolynomial(params double[] x) {
    		
		    foreach (double d in x)
			    if (Double.IsNaN(d))
				    return Double.NaN;
    		
		    return continuedPolynomial(x.Length, x);
    		
	    }
    	
	    /**
	     * Euler polynomial
	     * 
	     * @param      m                   the m parameter
	     * @param      x                   the x parameter
	     * 
	     * @return     if x <> Double.NaN and m>=0 returns polynomial value,
	     *             otherwise returns Double.NaN.
	     */
	    public static double eulerPolynomial(int m, double x) {
    		
		    if (Double.IsNaN(x))
			    return Double.NaN;
    		
    		
		    double result = Double.NaN;
    		
		    if (m >= 0) {
    			
			    result = 0;
    			
			    for (int n = 0; n <= m; n++) {
    				
				    for (int k = 0; k <= n; k++)
					    result += Math.Pow(-1, k) * binomCoeff(n, k) * Math.Pow(x+k, m);
    				
				    result /= Math.Pow(2, n);
    				
			    }
    				
    			
		    }
    		
		    return result;
    		
	    }
    	
	    /**
	     * Euler polynomial
	     * 
	     * @param      m                   the m parameter
	     * @param      x                   the x parameter
	     * 
	     * @return     if x,m <> Double.NaN returns eulerPolynomial( (int)Math.round(m), (int)Math.round(x) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double eulerPolynomial(double m, double x) {
    		
		    if (Double.IsNaN(m) || Double.IsNaN(x))
			    return Double.NaN;
    		
		    return eulerPolynomial( (int)Math.Round(m), (int)Math.Round(x) );

	    }	
    	
    	
	    /**
	     * Characteristic function x in (a,b)
	     * 
	     * @param      x                   the x value
	     * @param      a                   the left (lower) limit
	     * @param      b                   the right (upper) limit
	     * 
	     * @return     if x, a, b <> Double.NaN returns
	     * 			   characteristic function value on the (a,b) range.
	     */
	    public static double chi(double x, double a, double b) {

		    if (Double.IsNaN(x) || Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    				
		    double result = Double.NaN;
    		
		    if ( (!Double.IsNaN(x)) && (!Double.IsNaN(a)) && (!Double.IsNaN(b)) )
    			
			    if ( (x > a) && (x < b) )
				    result = 1;
			    else
				    result = 0;
    			
    		
		    return result;
    		
	    }
    	
	    /**
	     * Characteristic function x in [a,b]
	     * 
	     * @param      x                   the x value
	     * @param      a                   the left (lower) limit
	     * @param      b                   the right (upper) limit
	     * 
	     * @return     if x, a, b <> Double.NaN returns
	     * 			   characteristic function value on the [a,b] range.
	     */	
	    public static double CHi_LR(double x, double a, double b) {

		    if (Double.IsNaN(x) || Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    		
		    double result = Double.NaN;
    		
		    if ( (!Double.IsNaN(x)) && (!Double.IsNaN(a)) && (!Double.IsNaN(b)) )
    			
			    if ( (x >= a) && (x <= b) )
				    result = 1;
			    else
				    result = 0;
    			
    		
		    return result;
    		
	    }
    	
	    /**
	     * Characteristic function x in [a,b)
	     * 
	     * @param      x                   the x value
	     * @param      a                   the left (lower) limit
	     * @param      b                   the right (upper) limit
	     * 
	     * @return     if x, a, b <> Double.NaN returns
	     * 			   characteristic function value on the [a,b) range.
	     */	
	    public static double Chi_L(double x, double a, double b) {

		    if (Double.IsNaN(x) || Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    		
		    double result = Double.NaN;
    		
		    if ( (!Double.IsNaN(x)) && (!Double.IsNaN(a)) && (!Double.IsNaN(b)) )
    			
			    if ( (x >= a) && (x < b) )
				    result = 1;
			    else
				    result = 0;
    			
    		
		    return result;
    		
	    }
    	
	    /**
	     * Characteristic function x in (a,b]
	     * 
	     * @param      x                   the x value
	     * @param      a                   the left (lower) limit
	     * @param      b                   the right (upper) limit
	     * 
	     * @return     if x, a, b <> Double.NaN returns
	     * 			   characteristic function value on the (a,b] range.
	     */
	    public static double cHi_R(double x, double a, double b) {

		    if (Double.IsNaN(x) || Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;		
    		
		    double result = Double.NaN;
    		
		    if ( (!Double.IsNaN(x)) && (!Double.IsNaN(a)) && (!Double.IsNaN(b)) )
    			
			    if ( (x > a) && (x <= b) )
				    result = 1;
			    else
				    result = 0;
    			
    		
		    return result;
    		
	    }
    	
    	
    	
	    /**
	     * Power function a^b
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a,b <> Double.NaN returns Math.pow(a, b),
	     *             otherwise returns Double.NaN.
	     */
	    public static double power(double a, double b) {

		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    		
		    return Math.Pow(a, b);

	    }


	    /**
	     * Modulo operator a % b
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a,b <> Double.NaN returns a % b.
	     */
	    public static double mod(double a, double b) {
    		
		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;

		    return a % b;

	    }	
    	
	    /**
	     * Division a/b
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a,b <> Double.NaN and b <> 0 returns a/b,
	     *             otherwise return Double.NaN.
	     */
	    public static double div(double a, double b) {

		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    		
		    double result = Double.NaN;
    		
		    if (b != 0)
			    result = a / b;
    		
		    return result;
    		
	    }
    	


    	
	    /**
	     * Sine trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN return Math.sin(a),
	     *             otherwise return Double.NaN.
	     */	
	    public static double sin(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
    		
		    return Math.Sin(a);

	    }
    	
	    /**
	     * Cosine trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.cos(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double cos(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
    		
    		
		    return Math.Cos(a);

	    }

	    /**
	     * Tangent trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.tan(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double tan(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
    		
		    return Math.Tan(a);

	    }
    	
	    /**
	     * Cotangent trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and tan(a) <> 0 returns 1 / Math.tan(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double ctan(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    double tg = Math.Tan(a);
    		
		    if (tg != 0)
			    result = 1.0 / tg;
    		
		    return result;

	    }	

	    /**
	     * Secant trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and cos(a) <> 0 returns 1 / Math.cos(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double sec(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
    		
		    double result = Double.NaN;
    		
		    double cos = Math.Cos(a);
    		
		    if (cos != 0)
			    result = 1.0 / cos;		
    		
		    return result;

	    }	

	    /**
	     * Cosecant trigonometric function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and sin(a) <> 0 returns 1 / Math.sin(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double cosec(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    double sin = Math.Sin(a);
    		
		    if (sin != 0)
			    result = 1.0 / sin;			
    				
		    return result;

	    }
    	
	    /**
	     * Arcus sine - inverse trigonometric sine function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.asin(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double asin(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Asin(a);

	    }
    	
	    /**
	     * Arcus cosine - inverse trigonometric cosine function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.acos(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double acos(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Acos(a);

	    }

	    /**
	     * Arcus tangent - inverse trigonometric tangent function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.atan(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double atan(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Atan(a);

	    }
    	
	    /**
	     * Arcus cotangent - inverse trigonometric cotangent function
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a <> 0 returns Math.atan(1/a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double actan(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Atan(1/a);

	    }

	    /**
	     * Natural logarithm
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.log(1/a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double ln(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Log(a);

	    }
    	
	    /**
	     * Binary logarithm
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.log(a)/Math.log(2.0),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double log2(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Log(a)/Math.Log(2.0);

	    }
    	
	    /**
	     * Common logarithm
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.log10(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double log10(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Log10(a);

	    }
    	
	    /**
	     * Degrees to radius translation.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.toRadians(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double rad(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return a * (MathConstants.PI / 180.0);

	    }
    	
	    /**
	     * Exponential function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.exp(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double exp(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Exp(a);

	    }

	    /**
	     * Square root.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.sqrt(a),
	     *             otherwise returns Double.NaN.
	     */		
	     public static double sqrt(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Sqrt(a);

	    }
    	
	    /**
	     * Hyperbolic sine function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.sinh(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double sinh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Sinh(a);

	    }

	    /**
	     * Hyperbolic cosine function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.cosh(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double cosh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Cosh(a);

	    }
    	
	    /**
	     * Hyperbolic tangent function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.tanh(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double tanh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Tanh(a);

	    }

	    /**
	     * Hyperbolic cotangent function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and tanh(a) <> 0 returns 1 / Math.tanh(a),
	     *             otherwise returns Double.NaN.
	     */
	    public static double coth(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    double tanh = Math.Tanh(a);
    		
		    if (tanh != 0)
			    result = 1.0 / tanh;				
    		
		    return result;

	    }
    	
	    /**
	     * Hyperbolic secant function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and cosh(a) <> 0 returns 1 / Math.cosh(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double sech(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    double cosh = Math.Cosh(a);
    		
		    if (cosh != 0)
			    result = 1.0 / cosh;
    		
		    return result;

	    }

	    /**
	     * Hyperbolic cosecant function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and sinh(a) <> 0 returns 1 / Math.sinh(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double csch(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    double sinh = Math.Sinh(a);
    		
		    if (sinh != 0)
			    result = 1.0 / sinh;
    		
		    return result;

	    }

	    /**
	     * Radius to degrees translation.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.toDegrees(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double deg(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return a * (180.0 / MathConstants.PI);

	    }

	    /**
	     * Absolute value.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.abs(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double abs(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Abs(a);

	    }

	    /**
	     * Signum function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.signum(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double sgn(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
            
		    return Math.Sign(a);

	    }

	    /**
	     * Floor function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.floor(a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double floor(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Floor(a);

	    }
    	
	    /**
	     * Ceiling function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.ceil(a),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double ceil(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;
            
		    return Math.Ceiling(a);
    	
	    }
    	
	    /**
	     * Arcus hyperbolic sine - inverse hyperbolic sine function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.log(a + Math.sqrt(a*a+1)),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double arsinh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Log(a + Math.Sqrt(a*a+1));

	    }
    	
	    /**
	     * Arcus hyperbolic cosine - inverse hyperbolic cosine function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN returns Math.log(a + Math.sqrt(a*a-1)),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double arcosh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    return Math.Log(a + Math.Sqrt(a*a-1));

	    }
    	
	    /**
	     * Arcus hyperbolic tangent - inverse hyperbolic tangent function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and 1-a <> 0 returns 0.5*Math.log( (1+a)/(1-a) ),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double artanh(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    			
		    if (1-a != 0)
			    result = 0.5*Math.Log( (1+a)/(1-a) );		
    		
		    return result;

	    }
    	
	    /**
	     * Arcus hyperbolic tangent - inverse hyperbolic tangent function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a-1 <> 0 returns 0.5*Math.log( (a+1)/(a-1) );,
	     *             otherwise returns Double.NaN.
	     */	
	    public static double arcoth(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    if (a-1 != 0)
			    result = 0.5*Math.Log( (a+1)/(a-1) );			
    		
		    return result;

	    }
    	
	    /**
	     * Arcus hyperbolic secant - inverse hyperbolic secant function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a <> 0 returns Math.log( (1+Math.sqrt(1-a*a))/a);,
	     *             otherwise returns Double.NaN.
	     */		
	    public static double arsech(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    if (a != 0)
			    result = Math.Log( (1+Math.Sqrt(1-a*a))/a);	
    		
		    return result;

	    }
    	
	    /**
	     * Arcus hyperbolic cosecant - inverse hyperbolic cosecant function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a <> 0 returns Math.log( (1+Math.sqrt(1-a*a))/a);,
	     *             otherwise returns Double.NaN.
	     */	
	    public static double arcsch(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    if (a != 0)
			    result = Math.Log( 1/a + Math.Sqrt(1+a*a)/Math.Abs(a) );	
    		
		    return result;

	    }
    	
	    /**
	     * Normalized sinc function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a <> 0 returns Math.sin(PI*a) / (PI*a);,
	     *             otherwise returns Double.NaN.
	     */	
	    public static double sa(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double x = MathConstants.PI * a;
		    double result = Double.NaN;
    		
		    if (x != 0)
			    result = Math.Sin(x) / (x);	
    		
		    return result;

	    }	

	    /**
	     * Sinc function.
	     * 
	     * @param      a                   the a function parameter
	     * 
	     * @return     if a <> Double.NaN and a <> 0 returns Math.sin(a) / (a),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double sinc(double a) {

		    if (Double.IsNaN(a))
			    return Double.NaN;

		    double result = Double.NaN;
    		
		    if (a != 0)
			    result = Math.Sin(a) / (a);	
    		
		    return result;

	    }	
    	
	    /**
	     * General logarithm.
	     * 
	     * @param      a                   the a function parameter (base)
	     * @param      b                   the b function parameter (number)
	     * 
	     * @return     if a,b <> Double.NaN and log(b) <> 0 returns Math.log(a) / Math.log(b),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double log(double a, double b) {


		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;
    		
		    double result = Double.NaN;
    		
		    double logb = Math.Log(b);
    		
		    if (logb != 0)
			    result = Math.Log(a) / logb;
    		
		    return result;	

	    }
    	
	    /**
	     * Minimum function.
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a,b <> Double.NaN returns Math.min(a, b),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double min(double a, double b) {
    		
		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;

		    return Math.Min(a, b);	

	    }
    	
	    /**
	     * Minimum function.
	     * 
	     * @param      numbers             the a function parameter
	     * 
	     * @return     if each number form numbers <> Double.NaN returns the smallest number,
	     *             otherwise returns Double.NaN.
	     */	
	    public static double min(params double[] numbers) {

    		
		    double min = Double.PositiveInfinity;
    		
		    foreach (double number in numbers) {
    			
			    if (Double.IsNaN(number))
				    return Double.NaN;
    			
			    if (number < min)
				    min = number;
		    }

		    return min;
    		
	    }

	    /**
	     * Maximum function.
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a,b <> Double.NaN returns Math.max(a, b),
	     *             otherwise returns Double.NaN.
	     */		
	    public static double max(double a, double b) {
    		
		    if (Double.IsNaN(a) || Double.IsNaN(b))
			    return Double.NaN;

		    return Math.Max(a, b);	

	    }
    		
    	
	    /**
	     * Maximum function.
	     * 
	     * @param      numbers             the a function parameter
	     * 
	     * @return     if each number form numbers <> Double.NaN returns the highest number,
	     *             otherwise returns Double.NaN.
	     */		
	    public static double max(params double[] numbers) {

		    double max = Double.NegativeInfinity;
    				
		    foreach (double number in numbers) {
    			
			    if (Double.IsNaN(number))
				    return Double.NaN;			
    			
			    if (number > max)
				    max = number;
		    }

		    return max;
    		
	    }	

	    /**
	     * Greatest common divisor (GCD)
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * @return     GCD(a,b)
	     */
	    public static double gcd(int a, int b) {
    		
		    a = Math.Abs(a);
		    b = Math.Abs(b);
    		
		    if (a == 0)
			    return b;
    		
		    while (b != 0)
			    if (a > b)
				    a -= b;
			    else
				    b -= a;
    		
    		
		    return a;
    		
	    }
    	
	    /**
	     * Greatest common divisor (GCD)
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a, b <> Double.NaN returns gcd( (int)Math.round(a),(int)Math.round(b) ),
	     *             otherwise returns Double.NaN.
	     */
	    public static double gcd(double a, double b) {
    		
		    if ( Double.IsNaN(a) || Double.IsNaN(a) )
			    return Double.NaN;
    		
		    return gcd( (int)Math.Round(a),(int)Math.Round(b) );
    		
	    }
    	
	    /**
	     * Greatest common divisor (GCD)
	     * 
	     * @param      numbers             the numbers
	     * 
	     * @return     GCD(a_1,...,a_n) a_1,...,a_n in numbers
	     */
	    public static double gcd(params int[] numbers) {
    			
		    if (numbers.Length == 1)
			    return numbers[0];
    		
		    if (numbers.Length == 2)
			    return gcd( numbers[0], numbers[1] );
    		
    		
		    for (int i = 1; i < numbers.Length; i++)
			    numbers[i] = (int)gcd( numbers[i-1], numbers[i] );
    		
		    return numbers[numbers.Length-1];
	    }
    	
	    /**
	     * Greatest common divisor (GCD)
	     * 
	     * @param      numbers             the numbers
	     * 
	     * @return     if each number form numbers <> Double.NaN returns
	     *             GCD(a_1,...,a_n) a_1,...,a_n in numbers,
	     *             otherwise returns Double.NaN.
	     */
	    public static double gcd(params double[] numbers) {
    		
		    int[] intNumbers = new int[numbers.Length];
		    for(int i = 0; i < numbers.Length; i++) {
    			
			    double n = numbers[i];
    			
			    if ( Double.IsNaN(n) )
				    return Double.NaN;
    			
			    intNumbers[i] = (int)Math.Round(n);
    			
		    }
    		
		    return gcd(intNumbers);
    		
	    }	

	    /**
	     * Latest common multiply (LCM)
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     LCM(a,b)
	     */		
	    public static double lcm(int a, int b) {
    		
		    if ( (a == 0) || (b == 0) )
			    return 0;
    		
    		
		    return Math.Abs(a*b) / gcd(a, b);
    		
    		
	    }

	    /**
	     * Latest common multiply (LCM)
	     * 
	     * @param      a                   the a function parameter
	     * @param      b                   the b function parameter
	     * 
	     * @return     if a, b <> Double.NaN returns lcm( (int)Math.round(a), (int)Math.round(b) ),
	     *             otherwise returns Double.NaN.
	     */	
	    public static double lcm(double a, double b) {
    		
		    if ( Double.IsNaN(a) || Double.IsNaN(a) )
			    return Double.NaN;
    		
		    return lcm( (int)Math.Round(a), (int)Math.Round(b) );
    		
    		
	    }	

	    /**
	     * Latest common multiply (LCM)
	     * 
	     * @param      numbers             the numbers
	     * 
	     * @return     LCM(a_1,...,a_n) a_1,...,a_n in numbers
	     */	
	    public static double lcm(params int[] numbers) {
    		
		    if (numbers.Length == 1)
			    return numbers[0];
    		
		    if (numbers.Length == 2)
			    return lcm( numbers[0], numbers[1] );
    		
    		
		    for (int i = 1; i < numbers.Length; i++)
			    numbers[i] = (int)lcm( numbers[i-1], numbers[i] );
    		
		    return numbers[numbers.Length-1];
    		
	    }
    	
	    /**
	     * Latest common multiply (LCM)
	     * 
	     * @param      numbers             the numbers
	     * 
	     * @return     if each number form numbers <> Double.NaN returns
	     *             LCM(a_1,...,a_n) a_1,...,a_n in numbers,
	     *             otherwise returns Double.NaN.
	     */
	    public static double lcm(params double[] numbers) {
    		
		    int[] intNumbers = new int[numbers.Length];
		    for(int i = 0; i < numbers.Length; i++) {
    			
			    double n = numbers[i];
    			
			    if ( Double.IsNaN(n) )
				    return Double.NaN;
    			
			    intNumbers[i] = (int)Math.Round(n);
    			
			    if (intNumbers[i] == 0)
				    return 0;
    			
		    }
    		
		    return lcm(intNumbers);
    		
	    }		
    	
    }

}