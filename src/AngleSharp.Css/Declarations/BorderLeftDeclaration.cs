namespace AngleSharp.Css.Declarations
{
    using AngleSharp.Css.Dom;
    using AngleSharp.Css.Values;
    using AngleSharp.Text;
    using System;
    using static ValueConverters;

    static class BorderLeftDeclaration
    {
        public static String Name = PropertyNames.BorderLeft;

        public static String[] Shorthands = new[]
        {
            PropertyNames.Border,
        };

        public static IValueConverter Converter = new BorderLeftAggregator();

        public static PropertyFlags Flags = PropertyFlags.Animatable | PropertyFlags.Shorthand;

        public static String[] Longhands = new[]
        {
            PropertyNames.BorderLeftWidth,
            PropertyNames.BorderLeftStyle,
            PropertyNames.BorderLeftColor,
        };

        sealed class BorderLeftAggregator : IValueAggregator, IValueConverter
        {
            public ICssValue Convert(StringSource source)
            {
                return BorderSideConverter.Convert(source);
            }

            public ICssValue Merge(ICssValue[] values)
            {
                var width = values[0];
                var style = values[1];
                var color = values[2];

                if (width != null || style != null || color != null)
                {
                    return new CssTupleValue(new[] { width, style, color });
                }

                return null;
            }

            public ICssValue[] Split(ICssValue value)
            {
                var options = value as CssTupleValue;

                if (options != null)
                {
                    return new[]
                    {
                        options.Items[0],
                        options.Items[1],
                        options.Items[2],
                    };
                }

                return null;
            }
        }
    }
}
