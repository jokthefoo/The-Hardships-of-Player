using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class ScriptedCharMovement : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        bool[] jumps = new bool[9];
        bool onetime = false;
        float h = 0;

        public float timer = 4f;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            jumps[0] = true;
        }


        private void Update()
        {
            if (jumps[0])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -3.4f)
                    {
                        h = -0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[0] = false;
                        jumps[1] = true;
                        onetime = false;
                        timer = 1f;
                    }
                }
            }

            if (jumps[1])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -6.6f)
                    {
                        h = -0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[1] = false;
                        jumps[2] = true;
                        onetime = false;
                        timer = .9f;
                    }
                }
            }

            if (jumps[2])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -10.1f)
                    {
                        h = -0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[2] = false;
                        jumps[3] = true;
                        onetime = false;
                        timer = .8f;
                    }
                }
            }

            if (jumps[3])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -13.6f)
                    {
                        h = -0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[3] = false;
                        jumps[4] = true;
                        onetime = false;
                        timer = .7f;
                    }
                }
            }


            if (jumps[4])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x < -9.5f)
                    {
                        h = 0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[4] = false;
                        jumps[5] = true;
                        onetime = false;
                        timer = .6f;
                    }
                }
            }

            if (jumps[5])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x < -5.7f)
                    {
                        h = 0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[5] = false;
                        jumps[6] = true;
                        onetime = false;
                        timer = .5f;
                    }
                }
            }

            if (jumps[6])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -10.7)
                    {
                        h = -1.3f;
                    }
                    else
                    {
                        h = 0;
                        jumps[6] = false;
                        jumps[7] = true;
                        onetime = false;
                        timer = .4f;
                    }
                }
            }

            if (jumps[7])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x > -14.5f)
                    {
                        h = -0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[7] = false;
                        jumps[8] = true;
                        onetime = false;
                        timer = .3f;
                    }
                }
            }

            if (jumps[8])
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    if (!onetime)
                    {
                        oneJump();
                        onetime = true;
                    }
                    if (transform.position.x < -10.4f)
                    {
                        h = 0.7f;
                    }
                    else
                    {
                        h = 0;
                        jumps[8] = false;
                        onetime = false;
                    }
                }
            }
        }

        private void oneJump()
        {
            m_Jump = true;
        }

        private void FixedUpdate()
        {
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        }
    }
}
