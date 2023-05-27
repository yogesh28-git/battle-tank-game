using UnityEngine;
using BattleTank.PlayerTank;
using BattleTank.Bullets;
using BattleTank.EventSystem;
using System.Threading.Tasks;

namespace BattleTank.EnemyTank
{
    public class EnemyController: IDamagable
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; private set; }

        private Vector3 targetPos;
        private PlayerView playerRef;
        private float speed;
        private Transform shootPoint;
        private int BULLET_HIT_SCORE = 1;

        public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView )
        {
            this.EnemyModel = _enemyModel;
            this.EnemyView = _enemyView;
            this.playerRef = PlayerService.Instance.PlayerController.PlayerView;

            this.EnemyView.SetTankController( this );
            this.shootPoint = EnemyView.GetShootPoint( );
            this.speed = EnemyModel.MoveSpeed;
        }
        public void SetInitialPosition( )
        {
            EnemyView.transform.position = EnemyModel.GetStartingPoint( );
        }
        public void ResetPatrolPoints()
        {
            EnemyModel.UpdateStartingPoint( );
            this.targetPos = EnemyModel.GetStartingPoint( );
        }
        public void EnemyPatrol()
        {
            Vector3 currentPos = EnemyView.transform.position;

            if ( ( currentPos - targetPos ).sqrMagnitude < 1 )
            {
                ResetPatrolPoints( );
            }
            
            Vector3 newEnemyPos = Vector3.MoveTowards( currentPos, targetPos, speed * Time.deltaTime );
            EnemyView.transform.LookAt( targetPos );

            EnemyView.transform.position = newEnemyPos;
        }

        public void ChaseThePlayer( )
        {
            Vector3 playerPos = playerRef.transform.position;
            Vector3 enemyPos = EnemyView.transform.position;

            Vector3 newEnemyPos = Vector3.MoveTowards( enemyPos, playerPos, speed * Time.deltaTime );
            EnemyView.transform.LookAt( playerPos );

            EnemyView.transform.position = newEnemyPos;
        }

        public float AttackThePlayer(float timer, float delay)
        {
            Vector3 playerPos = playerRef.transform.position;
            EnemyView.transform.LookAt( playerPos );
            if ( timer > delay )
            {
                BulletService.Instance.Shoot( this , this.shootPoint );
                return 0;
            }
            return timer + Time.deltaTime;
        }
        public GameObject GetGameObject( )
        {
            return EnemyView.gameObject;
        }
        public int GiveDamage( )
        {
            return EnemyModel.Attack;
        }
        public void TakeDamage( int damage )
        {
            Debug.Log( "Enemy got hit" );
            int health = EnemyModel.Health - damage;
            health = health >= 0 ? health : 0;
            EnemyModel.SetHealth( health );

            EventService.Instance.OnBulletHit.InvokeEvent( BULLET_HIT_SCORE );

            if (health == 0 )
            {
                Death( );
            }
        }
        public async void Death( )
        {
            EventService.Instance.OnEnemyDeath.InvokeEvent( EnemyModel.Score );
            EnemyView.PlayDeathEffect( );
            await Task.Delay( 1000 );
            EnemyView.DestroyTank( );
            await Task.Delay( 5000 );
            EnemyService.Instance.CreateRandomEnemyTank( );
        }
    }
}
