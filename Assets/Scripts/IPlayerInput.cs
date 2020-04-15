using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    Vector3 CameraMoveDir();

    Vector3 CameraMoveDir(Transform trans);

    Vector3 PlayerMoveDir();

    Vector3 PlayerMoveDir(Transform trans);

    Vector3 LookDir();
}
