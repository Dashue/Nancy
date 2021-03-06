namespace Nancy.Testing
{
    using System;
    using System.Linq;
    using System.Threading;
    //using Xunit;

    /// <summary>
    /// Defines assert extensions for HTML validation.
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// Asserts that an element should exist at least once
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldExist(this NodeWrapper node)
        {
            Asserts.NotNull(node);

            return new AndConnector<NodeWrapper>(node);
        }

        /// <summary>
        /// Asserts that an element should exist at least once
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldExist(this QueryWrapper query)
        {
            Asserts.True(query.Any());

            return new AndConnector<QueryWrapper>(query);
        }

        /// <summary>
        /// Asserts that an element does not exist
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldNotExist(this QueryWrapper query)
        {
            Asserts.False(query.Any());

            return new AndConnector<QueryWrapper>(query);
        }

        /// <summary>
        /// Asserts that an element or element should exist one, and only once
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldExistOnce(this QueryWrapper query)
        {
            return new AndConnector<NodeWrapper>(Asserts.Single(query));
        }

        /// <summary>
        /// Asserts that an element should be of a specific class
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldBeOfClass(this NodeWrapper node, string className)
        {
            Asserts.Equal(node.Attributes["class"], className);

            return new AndConnector<NodeWrapper>(node);
        }

        /// <summary>
        /// Asserts that all elements should be of a specific class
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldBeOfClass(this QueryWrapper query, string className)
        {
            foreach (var node in query)
            {
                node.ShouldBeOfClass(className);
            }

            return new AndConnector<QueryWrapper>(query);
        }

        /// <summary>
        /// Asserts that a node contains the specified text
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldContain(this NodeWrapper node, string contents, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            Asserts.Contains(contents, node.InnerText, comparisonType);

            return new AndConnector<NodeWrapper>(node);
        }

        /// <summary>
        /// Asserts the every node should contain the specified text
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldContain(this QueryWrapper query, string contents, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            foreach (var node in query)
            {
                node.ShouldContain(contents, comparisonType);
            }

            return new AndConnector<QueryWrapper>(query);
        }

        /// <summary>
        /// Asserts that an element has a specific attribute
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldContainAttribute(this NodeWrapper node, string name)
        {
            Asserts.True(node.HasAttribute(name));

            return new AndConnector<NodeWrapper>(node);
        }

        /// <summary>
        /// Asserts that an element has a specific attribute with a specified value
        /// </summary>
        public static AndConnector<NodeWrapper> ShouldContainAttribute(this NodeWrapper node, string name, string value, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            Asserts.Equal(node.Attributes[name], value, comparisonType);

            return new AndConnector<NodeWrapper>(node);
        }

        /// <summary>
        /// Asserts that an element has a specific attribute
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldContainAttribute(this QueryWrapper query, string name)
        {
            foreach (var node in query)
            {
                node.ShouldContainAttribute(name);
            }

            return new AndConnector<QueryWrapper>(query);
        }

        /// <summary>
        /// Asserts that an element has a specific attribute with a specified value
        /// </summary>
        public static AndConnector<QueryWrapper> ShouldContainAttribute(this QueryWrapper query, string name, string value, StringComparison comparisonType = StringComparison.InvariantCulture)
        {
            foreach (var node in query)
            {
                node.ShouldContainAttribute(name, value);
            }

            return new AndConnector<QueryWrapper>(query);
        }
    }
}
