using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSequence : BatController
{
    private bool backwards = false;

    protected override void ChangeIndex()
    {
        float pointX = points[index].x;
        float pointY = points[index].y;
        if (Mathf.Abs(transform.position.x - pointX) < 0.2 && Mathf.Abs(transform.position.y - pointY) < 0.2) //������ ���������, ��������������� ������ �� � ��'���� �� � ����� � ������ �� � ��'���� �� � �����. Mathf.Abs() �� ������ ������, ��� ���������� �����.

        {
            if (backwards)
            {
                index--;
            }
            else
            {
                index++;
            }
        }
        if (index == points.Count)
        {
            index -= 2;
            backwards = true;
        }
        if (index <= -1)
        {
            index += 2;
            backwards = false;
        }
    }
}


