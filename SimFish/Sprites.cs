using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Sprites
{
    public class Sprite
    {
        private Texture2D tex;
        private Vector2 pos;
        private Color col = Color.White;
        private Vector2 size;
        private bool flip;

        public Color Color
        {
            get { return col; }
            set { col = value; }
        }

        public Vector2 Position
        {
            get { return pos; }
            set { pos = value; }
        }

        public Texture2D Texture
        {
            get { return tex; }
            set { tex = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public bool Flip
        {
            get { return flip; }
            set { flip = value; }
        }

        public virtual void Update(GameTime gt) { }
        public virtual void Update(GameTime gt, GraphicsDeviceManager gr) { }

        public virtual void Draw(SpriteBatch sb)
        {
            //sb.Draw(this.Texture, this.Position, this.Color);

            //sb.Draw(this.Texture, new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y), this.col);
            SpriteEffects effect = SpriteEffects.None;
            if (flip) { effect = SpriteEffects.FlipHorizontally; }
            sb.Draw(this.Texture, new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y), null, this.col, 0.0f, new Vector2(0.0f, 0.0f), effect, 1.0f);
        }

    }

    class Fish : Sprite
    {
        public override void Update(GameTime gt, GraphicsDeviceManager gr)
        {
            if (this.Position.X > gr.PreferredBackBufferWidth-20)
            {
                this.Position = new Vector2(0.0f, this.Position.Y);
            }
            else if (this.Position.X < 0.0f)
            {
                this.Position = new Vector2(gr.PreferredBackBufferWidth-20, this.Position.Y);
            }

            if (this.Position.Y > gr.PreferredBackBufferHeight-20)
            {
                this.Position = new Vector2(this.Position.X, 0.0f);
            }
            else if (this.Position.Y < 0.0f)
            {
                this.Position = new Vector2(this.Position.X, gr.PreferredBackBufferHeight-20);
            }
            //this.Position += new Vector2(0.5f, 0.0f);
        }
    }
}