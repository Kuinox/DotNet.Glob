using System;
using System.Text;
using DotNet.Globbing.Token;

namespace DotNet.Globbing.Generation
{
    internal class AnyCharacterTokenMatchGenerator : IMatchGenerator
    {
        private AnyCharacterToken token;
        private Random _random;

        public AnyCharacterTokenMatchGenerator(AnyCharacterToken token, Random _random)
        {
            this.token = token;
            this._random = _random;
        }

        public void AppendMatch(StringBuilder builder)
        {
            // append a random single literal char.
            builder.AppendRandomLiteralCharacter(_random);
        }

        public void AppendNonMatch(StringBuilder builder)
        {
            // We can match any single character, 
            // the only thing we wont match against is a directory separator.
            if (_random.Next(0, 1) == 0)
            {
                builder.Append('/');
            }
            else
            {
                builder.Append('\\');
            }

        }
    }
}