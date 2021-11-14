# Lecture 6 code patched

## Changes:
+ Added DrawDoubleBuffer
	```c#

	void DrawDoubleBuffer(Graphics g)
    {
            DrawScene(Graphics.FromImage(offscreen));
            g.DrawImage(offscreen, 0, 0);
    }

	```
+ Commented out unimplemented `Rotateall` method
    ```c#
    case Keys.T:
            Transform.RotateArbitrary(cubes[1], cubes[0].points[3], cubes[0].points[7], 1);
            //Transform.Rotateall(cubes[2], cubes[0].points[3], cubes[0].points[7], 1);
            //Transform.Rotateall(cubes[0], cubes[0].points[3], cubes[0].points[7], 1);
            break;
    ```
+   Changed `RotateX, RotateY and RotateZ` to accept `_3DModel` as first parameter instead of list of points

+ Fixed Translate method calling according to its segneture
    ```c#
    Transform.Translate(L_Pts,0,0, v1.z * 1);//Returns the Z values of v1 to original place
    Transform.Translate(L_Pts,0, v1.y * 1,0);//Returns the Y values of v1 to original place
    Transform.Translate(L_Pts, v1.x * 1,0,0);//Returns the X values of v1 to original place
    ```

+ Fixed methods and fields naming according to [C# coding style](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)