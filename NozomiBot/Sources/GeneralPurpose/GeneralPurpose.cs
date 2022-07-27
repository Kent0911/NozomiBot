using System;

namespace NozomiBot.GeneralPurpose {
    public class Common {
#pragma warning disable CA1715 // 識別子は正しいプレフィックスを含んでいなければなりません
#pragma warning disable CA1707 // 識別子はアンダースコアを含むことはできません
        public static int Digit <Type> ( Type _id ) where Type : IComparable {
            return _id.Equals( 0 ) ? 1 : (( int ) MathF.Log10 (( float )( dynamic ) _id ) + 1 );
        }
#pragma warning restore CA1715
#pragma warning restore CA1707
    }
}
