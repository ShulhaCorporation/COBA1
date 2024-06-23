using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLooped : BatController
{
    
    protected override void ChangeIndex()
    {
        float pointX = points[index].x;
            float pointY = points[index].y;
            if (Mathf.Abs(transform.position.x - pointX) < 0.2 && Mathf.Abs(transform.position.y - pointY) < 0.2) //������ ���������, ��������������� ������ �� � ��'���� �� � ����� � ������ �� � ��'���� �� � �����. Mathf.Abs() �� ������ ������, ��� ���������� �����.

            { 
            
                index++;
            }
        if (index == points.Count)
        {
          
            index = 0;
        }
    }
}


