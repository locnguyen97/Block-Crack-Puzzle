using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Car : MonoBehaviour
{

    public int index;
    
    
    private void OnMouseDown()
    {
        if (GameManager.Instance.canDrag)
        {
            GameManager.Instance.canDrag = false;
            int id = GameManager.Instance.CheckObject();
            if (id == 1)
            {
                transform.DOScale(new Vector2(1.15f, 1.15f), 0.15f).OnComplete(() =>
                {
                    GameManager.Instance.EnableDrag();
                    GameManager.Instance.curCar = this;
                });
            }
            else
            {
                if (GameManager.Instance.curCar == this)
                {
                    GameManager.Instance.EnableDrag();
                    return;
                }
                else
                {
                    if (GameManager.Instance.curCar.name == transform.name)
                    {
                        GameManager.Instance.curCar.transform.DOScale(new Vector2(1.5f, 1.5f), 0.2f).OnComplete(() =>
                        {
                            GameManager.Instance.GetCurLevel().RemoveObject(GameManager.Instance.curCar.gameObject);
                            Destroy(GameManager.Instance.curCar.gameObject);
                        });
                    
                        transform.DOScale(new Vector2(1.5f, 1.5f), 0.2f).OnComplete(() =>
                        {
                            GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
                            Destroy(gameObject);
                            GameManager.Instance.curCar = null;
                            GameManager.Instance.EnableDrag();
                        });
                    }
                    else
                    {
                        GameManager.Instance.curCar.transform.DOScale(Vector3.one, 0.15f).OnComplete(() =>
                        {
                            GameManager.Instance.curCar = null;
                            GameManager.Instance.EnableDrag();
                        });
                    }
                }
            }
        }
    }
    
}
