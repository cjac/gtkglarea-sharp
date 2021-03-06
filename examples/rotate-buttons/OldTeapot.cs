// created on 11/25/2005 at 11:13 AM
using Tao.OpenGl;
using gl=Tao.OpenGl.Gl;
using System;
using System.Collections;

namespace GtkGL {
	public class OldTeapot : GtkGL.OldGLObjectBase,GtkGL.IGLObject { 
		  /* 
		   * Teapot
		   */

		  /* Rim, body, lid, and bottom data must be reflected in x and
		     y; handle and spout data across the y axis only.  */

		  static int[,] patchdata =
		    {
		      /* rim */
		      {102, 103, 104, 105, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
		      /* body */
		      {12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27},
		      {24, 25, 26, 27, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40},
		      /* lid */
		      {96, 96, 96, 96, 97, 98, 99, 100, 101, 101, 101, 101, 0, 1, 2, 3,},
		      {0, 1, 2, 3, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117},
		      /* bottom */
		      {118, 118, 118, 118, 124, 122, 119, 121, 123, 126, 125, 120, 40, 39, 38, 37},
		      /* handle */
		      {41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56},
		      {53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 28, 65, 66, 67},
		      /* spout */
		      {68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83},
		      {80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95}
		    };
		  /* *INDENT-OFF* */

		  static double[,] cpdata =
		    {
		      {0.2, 0, 2.7}, {0.2, -0.112, 2.7}, {0.112, -0.2, 2.7},
		      {0,-0.2, 2.7}, {1.3375, 0, 2.53125}, {1.3375, -0.749, 2.53125},
		      {0.749, -1.3375, 2.53125}, {0, -1.3375, 2.53125}, {1.4375,0, 2.53125},
		      {1.4375, -0.805, 2.53125}, {0.805, -1.4375,2.53125}, {0, -1.4375, 2.53125},
		      {1.5, 0, 2.4}, {1.5, -0.84, 2.4}, {0.84, -1.5, 2.4},
		      {0, -1.5, 2.4}, {1.75, 0, 1.875},
		      {1.75, -0.98, 1.875}, {0.98, -1.75, 1.875}, {0, -1.75, 1.875},
		      {2, 0, 1.35}, {2, -1.12, 1.35}, {1.12, -2, 1.35},
		      {0, -2, 1.35}, {2, 0, 0.9}, {2, -1.12, 0.9},
		      {1.12, -2, 0.9}, {0, -2, 0.9}, {-2, 0, 0.9},
		      {2, 0, 0.45}, {2, -1.12, 0.45}, {1.12, -2, 0.45},
		      {0, -2, 0.45}, {1.5, 0, 0.225},
		      {1.5, -0.84, 0.225}, {0.84, -1.5, 0.225}, {0, -1.5, 0.225},
		      {1.5, 0, 0.15}, {1.5, -0.84, 0.15}, {0.84, -1.5, 0.15},
		      {0, -1.5, 0.15}, {-1.6, 0, 2.025}, {-1.6, -0.3, 2.025},
		      {-1.5, -0.3, 2.25}, {-1.5, 0, 2.25}, {-2.3, 0, 2.025},
		      {-2.3, -0.3, 2.025}, {-2.5, -0.3, 2.25}, {-2.5, 0, 2.25},
		      {-2.7, 0, 2.025}, {-2.7, -0.3, 2.025}, {-3, -0.3, 2.25},
		      {-3, 0, 2.25}, {-2.7, 0, 1.8}, {-2.7, -0.3, 1.8},
		      {-3, -0.3, 1.8}, {-3, 0, 1.8}, {-2.7, 0, 1.575},
		      {-2.7, -0.3, 1.575}, {-3, -0.3, 1.35}, {-3, 0, 1.35},
		      {-2.5, 0, 1.125}, {-2.5, -0.3, 1.125}, {-2.65, -0.3, 0.9375},
		      {-2.65, 0, 0.9375}, {-2, -0.3, 0.9}, {-1.9, -0.3, 0.6},
		      {-1.9, 0, 0.6}, {1.7, 0, 1.425}, {1.7, -0.66, 1.425},
		      {1.7, -0.66, 0.6}, {1.7, 0, 0.6}, {2.6, 0, 1.425},
		      {2.6, -0.66, 1.425}, {3.1, -0.66, 0.825}, {3.1, 0, 0.825},
		      {2.3, 0, 2.1}, {2.3, -0.25, 2.1},
		      {2.4, -0.25, 2.025}, {2.4, 0, 2.025}, {2.7, 0, 2.4},
		      {2.7, -0.25, 2.4}, {3.3, -0.25, 2.4}, {3.3, 0, 2.4},
		      {2.8, 0, 2.475}, {2.8, -0.25, 2.475}, {3.525, -0.25, 2.49375},
		      {3.525, 0, 2.49375}, {2.9, 0, 2.475}, {2.9, -0.15, 2.475},
		      {3.45, -0.15, 2.5125}, {3.45, 0, 2.5125}, {2.8, 0, 2.4},
		      {2.8, -0.15, 2.4}, {3.2, -0.15, 2.4}, {3.2, 0, 2.4},
		      {0, 0, 3.15}, {0.8, 0, 3.15}, {0.8, -0.45, 3.15},
		      {0.45, -0.8, 3.15}, {0, -0.8, 3.15}, {0, 0, 2.85},
		      {1.4, 0, 2.4}, {1.4, -0.784, 2.4}, {0.784, -1.4, 2.4},
		      {0, -1.4, 2.4}, {0.4, 0, 2.55}, {0.4, -0.224, 2.55},
		      {0.224, -0.4, 2.55}, {0, -0.4, 2.55}, {1.3, 0, 2.55}, {1.3, -0.728, 2.55}, {0.728, -1.3, 2.55}, {0, -1.3, 2.55}, {1.3, 0, 2.4}, {1.3, -0.728, 2.4},
		      {0.728, -1.3, 2.4}, {0, -1.3, 2.4}, {0, 0, 0}, {1.425, -0.798, 0}, {1.5, 0, 0.075}, {1.425, 0, 0}, {0.798, -1.425, 0}, {0, -1.5, 0.075}, {0, -1.425, 0}, {1.5, -0.84, 0.075},
		      {0.84, -1.5, 0.075}
		    };

                  static float[/*2*2*2*/] tex =
		    {
                        0, 0,
                        1, 0,

                        0, 1,
                        1, 1
		    };

		  /* *INDENT-ON* */
		  
		  	static float[][]
		  		cachedP = new float[10][],
			  	cachedQ = new float[10][],
			  	cachedR = new float[10][],
			  	cachedS = new float[10][];

		  	private void DoTeaPot(int grid, double scale, int type)
		  	{
			
			    gl.glPushAttrib(gl.GL_ENABLE_BIT | gl.GL_EVAL_BIT);
			    gl.glEnable(gl.GL_AUTO_NORMAL);
			    gl.glEnable(gl.GL_NORMALIZE);
			    gl.glEnable(gl.GL_MAP2_VERTEX_3);
			    gl.glEnable(gl.GL_MAP2_TEXTURE_COORD_2);
			    gl.glPushMatrix();
			    gl.glRotatef(270.0f, 1.0f, 0.0f, 0.0f);
			    gl.glScalef((float)(0.5 * scale), (float)(0.5 * scale), (float)(0.5 * scale));
		    	gl.glTranslatef(0.0f, 0.0f, -1.5f);
		    
		    	float[,,]
		    		p = new float[4,4,3],
		    		q = new float[4,4,3],
		    		r = new float[4,4,3],
					s = new float[4,4,3];
		    	int i, j, k, l;
			    
			   	for (i = 0; i < 10; i++) {
			   	
				   	if(cachedP[i] == null){
				      	for (j = 0; j < 4; j++) {
							for (k = 0; k < 4; k++) {
					  			for (l = 0; l < 3; l++) {
					    			p[j,k,l] = (float)cpdata[patchdata[i,j * 4 + k],l];
					    			q[j,k,l] = (float)cpdata[patchdata[i,j * 4 + (3 - k)],l];
					    			if (l == 1)
						      			q[j,k,l] *= -1.0f;
					    			if (i < 6) {
					      				r[j,k,l] = (float)cpdata[patchdata[i,j * 4 + (3 - k)],l];
					      				if (l == 0)
											r[j,k,l] *= -1.0f;
					      				s[j,k,l] = (float)cpdata[patchdata[i,j * 4 + k],l];
					      				if (l == 0)
											s[j,k,l] *= -1.0f;
					      				if (l == 1)
											s[j,k,l] *= -1.0f;
						    		}
					  			}
							}
		    	  		}
			          
			    	  	cachedP[i] = new float[4*4*3];
		    		  	cachedQ[i] = new float[4*4*3];
		    		  	cachedR[i] = new float[4*4*3];
		    		  	cachedS[i] = new float[4*4*3];

				      	int pos;
			    	  	pos = 0;
						for(int I = 0; I < 4; I++)
			    	  		for(int J = 0; J < 4; J++)
			    	  			for(int K = 0; K < 3; K++,pos++){
					  				cachedP[i][pos] = p[I,J,K];
			    	  				cachedQ[i][pos] = q[I,J,K];
			    	  				cachedR[i][pos] = r[I,J,K];
			    	  				cachedS[i][pos] = s[I,J,K];
			    	  			}    	  			
		    	  	}

                                gl.glMap2f(gl.GL_MAP2_TEXTURE_COORD_2, 0, 1, 2, 2, 0, 1, 4, 2, tex);
		    		gl.glMap2f(gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, cachedP[i]);
		    		gl.glMapGrid2f(grid, 0.0f, 1.0f, grid, 0.0f, 1.0f);
		    		gl.glEvalMesh2(type, 0, grid, 0, grid);
		    		gl.glMap2f(gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, cachedQ[i]);
		    		gl.glEvalMesh2(type, 0, grid, 0, grid);
		    		if (i < 6) {
						gl.glMap2f(gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, cachedR[i]);
						gl.glEvalMesh2(type, 0, grid, 0, grid);
						gl.glMap2f(gl.GL_MAP2_VERTEX_3, 0, 1, 3, 4, 0, 1, 12, 4, cachedS[i]);
						gl.glEvalMesh2(type, 0, grid, 0, grid);
		  			}
		  		}
		    	gl.glPopMatrix();
		    	gl.glPopAttrib();
		  	}
		  	
			protected override void DrawObject()
			{
				bool solid = true;
				double scale = 0.5; 
		  
			  	if (solid)
			    	DoTeaPot (7, scale, gl.GL_FILL);
			  	else
				    DoTeaPot (10, scale, gl.GL_LINE);
			}
		}
}
