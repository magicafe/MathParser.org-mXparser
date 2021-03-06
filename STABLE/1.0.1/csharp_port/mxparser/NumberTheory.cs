/*
 * @(#)NumberTheory.cs        1.0    2010-02-20
 * 
 * You may use this software under the condition of "Simplified BSD License"
 * 
 * Copyright 2010 MARIUSZ GROMADA. All rights reserved.
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
 *     mariusz.gromada@gmail.com
 *     http://multifraktal.net/
 *     http://mxparser.sourceforge.net/
 * 
 *                              Asked if he believes in one God, a mathematician answered: 
 *                              "Yes, up to isomorphism."  
 */

using System;
using org.mariuszgromada.math.mxparser;

namespace org.mariuszgromada.math.mxparser.mathcollection {


    /**
     * NumberTheory - summation / products etc... 
     * 
     * @author         <b>Mariusz Gromada</b><br/>
     *                 <a href="mailto:mariusz.gromada@gmail.com">mariusz.gromada@gmail.com</a><br>
     *                 <a href="http://multifraktal.net/">http://multifraktal.net/</a><br>
     *                 <a href="http://mxparser.sourceforge.net/">http://mxparser.sourceforge.net/</a><br>
     *                         
     * @version        1.0
     */
    public sealed class NumberTheory {
    	
    	
	    /**
	     * Summation operator (SIGMA FROM i = a, to b,  f(i) by delta
	     * 
	     * @param      f                   the expression
	     * @param      index               the name of index argument
	     * @param      from                FROM index = form
	     * @param      to                  TO index = to
	     * @param      delta               BY delta
	     * 
	     * @return     summation operation (for empty summation operations returns 0).
	     */
	    public static double sigmaSummation(Expression f, Argument index, double from, double to, double delta) {
    		
		    double result = 0;

		    if ( (Double.IsNaN(delta) ) || (Double.IsNaN(from) ) || (Double.IsNaN(to) ) ) 
			    return Double.NaN;
    			
		    if ( (to >= from) && (delta > 0) ) {
    				
			    for (double i = from; i < to; i+=delta)
				    result += mXparser.getFunctionValue(f, index, i);
    				
			    result += mXparser.getFunctionValue(f, index, to);
    								
		    } else if ( (to <= from) && (delta < 0) ) {
    			
			    for (double i = from; i > to; i+=delta)
				    result += mXparser.getFunctionValue(f, index, i);
    			
			    result += mXparser.getFunctionValue(f, index, to);
    			
		    } else if (from == to)
			    result += mXparser.getFunctionValue(f, index, from);							
    					
    		
		    return result;
    		
	    }
    	

	    /**
	     * Product operator
	     * 
	     * @param      f                   the expression
	     * @param      index               the name of index argument
	     * @param      from                FROM index = form
	     * @param      to                  TO index = to
	     * @param      delta               BY delta
	     * 
	     * @return     product operation (for empty product operations returns 1).
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double piProduct(Expression f, Argument index, double from, double to, double delta) {

		    if ( (Double.IsNaN(delta) ) || (Double.IsNaN(from) ) || (Double.IsNaN(to) ) )
			    return Double.NaN;
    		
		    double result = 1;
    			
		    if ( (to >= from) && (delta > 0) ) {
    			
			    for (double i = from; i < to; i+=delta)
				    result *= mXparser.getFunctionValue(f, index, i);
    			
			    result *= mXparser.getFunctionValue(f, index, to);
    							
		    } else if ( (to <= from) && (delta < 0) ) {
    			
			    for (double i = from; i > to; i+=delta)
				    result *= mXparser.getFunctionValue(f, index, i);
    		
			    result *= mXparser.getFunctionValue(f, index, to);
    			
		    } else if (from == to)
			    result *= mXparser.getFunctionValue(f, index, from);
    					
		    return result;
    		
	    }	
    	
	    /**
	     * Forward difference(1) operator (at x = x0)
	     * 
	     * @param      f                   the expression
	     * @param      x                   the argument name
	     * @param      x0                  x = x0
	     *                    
	     * @return     Forward difference(1) value calculated at x0.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double forwardDifference(Expression f, Argument x, double x0) {
    		
		    if (Double.IsNaN(x0))
			    return Double.NaN;
    		
		    double xb = x.getArgumentValue();
    		
		    double delta = mXparser.getFunctionValue(f, x, x0+1) - mXparser.getFunctionValue(f, x, x0);
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    		

	    /**
	     * Forward difference(1) operator (at current value of argument x)
	     * 
	     * @param      f                   the expression
	     * @param      x                   the argument name
	     *                    
	     * @return     Forward difference(1) value calculated at the current value of argument x.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double forwardDifference(Expression f, Argument x) {
		    double xb = x.getArgumentValue();
    		
		    if (Double.IsNaN(xb))
			    return Double.NaN;
    		
		    double fv = f.calculate();
		    x.setArgumentValue(xb + 1);
    		
		    double delta = f.calculate() - fv;
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    	
    	
	    /**
	     * Backward difference(1) operator (at x = x0)
	     * 
	     * @param      f                   the expression
	     * @param      x                   the argument name
	     * @param      x0                  x = x0
	     *                    
	     * @return     Backward difference value calculated at x0.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */	
	    public static double backwardDifference(Expression f, Argument x, double x0) {

		    if (Double.IsNaN(x0))
			    return Double.NaN;
    		
		    double xb = x.getArgumentValue();
    		
		    double delta = mXparser.getFunctionValue(f, x, x0) - mXparser.getFunctionValue(f, x, x0-1);
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    		
	    /**
	     * Backward difference(1) operator (at current value of argument x)
	     * 
	     * @param      f                   the expression
	     * @param      x                   the argument name
	     *                    
	     * @return     Backward difference(1) value calculated at the current value of argument x.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double backwardDifference(Expression f, Argument x) {
    		
		    double xb = x.getArgumentValue();
    		
		    if (Double.IsNaN(xb))
			    return Double.NaN;
    		
		    double fv = f.calculate();
		    x.setArgumentValue(xb - 1);
    		
		    double delta = fv - f.calculate();
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }	
    	
    	
	    /**
	     * Forward difference(h) operator (at x = x0)
	     * 
	     * @param      f                   the expression
	     * @param      h                   the difference
	     * @param      x                   the argument name
	     * @param      x0                  x = x0
	     * 
	     * @return     Forward difference(h) value calculated at x0.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double forwardDifference(Expression f, double h, Argument x, double x0) {
    		
		    if (Double.IsNaN(x0))
			    return Double.NaN;
    		
		    double xb = x.getArgumentValue();
    		
		    double delta = mXparser.getFunctionValue(f, x, x0+h) - mXparser.getFunctionValue(f, x, x0);
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    		

	    /**
	     * Forward difference(h) operator (at the current value of the argument x)
	     * 
	     * @param      f                   the expression
	     * @param      h                   the difference
	     * @param      x                   the argument name
	     * 
	     * @return     Forward difference(h) value calculated at at the current value of the argument x.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double forwardDifference(Expression f,  double h, Argument x) {
    		
		    double xb = x.getArgumentValue();
    		
		    if (Double.IsNaN(xb))
			    return Double.NaN;
    		
		    double fv = f.calculate();
		    x.setArgumentValue(xb + h);
    		
		    double delta = f.calculate() - fv;
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    	
	    /**
	     * Backward difference(h) operator (at x = x0)
	     * 
	     * @param      f                   the expression
	     * @param      h                   the difference
	     * @param      x                   the argument name
	     * @param      x0                  x = x0
	     * 
	     * @return     Backward difference(h) value calculated at x0.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */	
	    public static double backwardDifference(Expression f,  double h, Argument x, double x0) {
    		
		    if (Double.IsNaN(x0))
			    return Double.NaN;
    		
		    double xb = x.getArgumentValue();
    		
		    double delta = mXparser.getFunctionValue(f, x, x0) - mXparser.getFunctionValue(f, x, x0-h);
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }
    		
	    /**
	     * Backward difference(h) operator (at the current value of the argument x)
	     * 
	     * @param      f                   the expression
	     * @param      h                   the difference
	     * @param      x                   the argument name
	     * 
	     * @return     Backward difference(h) value calculated at at the current value of the argument x.
	     * 
	     * @see        Expression
	     * @see        Argument
	     */
	    public static double backwardDifference(Expression f,  double h, Argument x) {
    		
		    double xb = x.getArgumentValue();

		    if (Double.IsNaN(xb))
			    return Double.NaN;

		    double fv = f.calculate();
		    x.setArgumentValue(xb - h);
    		
		    double delta = fv - f.calculate();
		    x.setArgumentValue(xb);
    		
		    return delta;
    		
	    }	
    	
    }

}