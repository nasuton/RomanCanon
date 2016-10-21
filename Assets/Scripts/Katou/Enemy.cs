using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Move,
    Attack,
    Explode,
}

public class Enemy : StatefulObjectBase<Enemy, EnemyState>
{
    private Vector3 player;

    private float maxlife = 3;
    private float life;

    private float speed = 10.0f;
    private float rotationSmooth = 1.0f;
    private float interval = 2.0f;
    private float attackSqrDistance = 10.0f;
    private float margin = 10.0f;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        player = Vector3.zero;

        life = maxlife;

        //ステートマシンの追加
        stateList.Add(new StateMove(this));
        stateList.Add(new StateAttack(this));
        stateList.Add(new StateExplode(this));
    }

    public void TakeDamege()
    {
        life--;
        if(life <= 0)
        {
            ChangeState(EnemyState.Explode);
        }
    }

    #region States

    private class StateMove : State<Enemy>
    {
        public StateMove(Enemy owner) : base(owner) { }

        public override void Enter() { }

        public override void Execute()
        {
            float DistanceToPlayer = Vector3.SqrMagnitude(owner.transform.position - owner.player);
            if(DistanceToPlayer < owner.attackSqrDistance - owner.margin)
            {
                owner.ChangeState(EnemyState.Attack);
            }

            Quaternion targetRotation = Quaternion.LookRotation(owner.player - owner.transform.position);
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime * owner.rotationSmooth);

            owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);
        }


        public override void Exit() { }
    }

    private class StateAttack : State<Enemy>
    {
        private float lastAttackTime;

        public StateAttack(Enemy owner) : base(owner) { }

        public override void Enter() { }

        public override void Execute()
        {
            if(Time.time > lastAttackTime + owner.interval)
            {
                
                lastAttackTime = Time.time;
            }
        }

        public override void Exit() { }
    }

    private class StateExplode : State<Enemy>
    {
        public StateExplode(Enemy owner) : base(owner) { }

        public override void Enter()
        {
            Destroy(owner.gameObject, 1.0f);
        }

        public override void Execute() { }

        public override void Exit() { }
    }

     #endregion
}