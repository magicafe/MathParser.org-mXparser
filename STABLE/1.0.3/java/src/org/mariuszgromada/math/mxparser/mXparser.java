/*
 * @(#)mXparser.java        1.0.3    2015-12-15
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
 *     
 *     http://mathspace.plt/
 *     http://mxparser.sourceforge.net/
 * 
 *                              Asked if he believes in one God, a mathematician answered: 
 *                              "Yes, up to isomorphism."  
 */ 


package org.mariuszgromada.math.mxparser;

import java.util.ArrayList;

/**
 * mXparser class provides usefull methods when parsing, calculating or
 * parameters transforming.
 * 
 * @author         <b>Mariusz Gromada</b><br/>
 *                 <a href="mailto:"></a><br>
 *                 <a href="http://mathspace.plt/">http://mathspace.plt/</a><br>
 *                 <a href="http://mxparser.sourceforge.net/">http://mxparser.sourceforge.net/</a><br>
 *                         
 * @version        1.0
 * 
 * @see RecursiveArgument
 * @see Expression
 * @see Function
 * @see Constant
 */
public final class mXparser {
	
	/**
	 * Calculates function f(x0) (given as expression) assigning Argument x = x0;
	 * 
	 * 
	 * @param      f                   the expression
	 * @param      x                   the argument
	 * @param      x0                  the argument value
	 * 
	 * @return     f.calculate()
	 * 
	 * @see        Expression
	 */
	public static final double getFunctionValue(Expression f, Argument x, double x0) {

		x.setArgumentValue(x0);
		return f.calculate();

	}	
	
	
	/**
	 * Converts ArrayList<Double> to double[]
	 * 
	 * @param      numbers             the numbers list
	 * 
	 * @return     numbers array
	 */
	public static final double[] arraList2double(ArrayList<Double> numbers) {

		if (numbers == null)
			return null;
		
		int size = numbers.size();
		double[] newNumbers = new double[size];
		
		for (int i = 0; i < size; i++)
			newNumbers[i] = numbers.get(i).doubleValue();
		
		return newNumbers;
		
		
	}
	
	
	/**
	 * Prints object.toString to the Console + new line
	 * 
	 * @param o    Object to print
	 */
	public static final void consolePrintln(Object o) {
		System.out.println(o);		
	}
	
	public static final void consolePrintln() {
		System.out.println();		
	}
	
	/**
	 * Prints object.toString to the Console
	 * 
	 * @param o    Object to print
	 */
	public static final void consolePrint(Object o) {
		System.out.print(o);		
	}
}
