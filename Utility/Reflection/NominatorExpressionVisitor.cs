//-----------------------------------------------------------------------
// <copyright file="NominatorExpressionVisitor.cs" company="YuGuan Corporation">
//     Copyright (c) YuGuan Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RMS.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Performs bottom-up analysis to determine which nodes can possibly be part of an evaluated sub-tree.
    /// </summary>
    public class NominatorExpressionVisitor : ExpressionVisitor
    {
        /// <summary>
        /// Field _fnCanBeEvaluated.
        /// </summary>
        private Func<Expression, bool> m_fnCanBeEvaluated;

        /// <summary>
        /// Field _candidates.
        /// </summary>
        private HashSet<Expression> m_candidates;

        /// <summary>
        /// Field _cannotBeEvaluated.
        /// </summary>
        private bool m_cannotBeEvaluated;

        /// <summary>
        /// Initializes a new instance of the <see cref="NominatorExpressionVisitor" /> class.
        /// </summary>
        /// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
        internal NominatorExpressionVisitor(Func<Expression, bool> fnCanBeEvaluated)
        {
            this.m_fnCanBeEvaluated = fnCanBeEvaluated;
        }

        /// <summary>
        /// Dispatches the expression to one of the more specialized visit methods in this class.
        /// </summary>
        /// <param name="expression">The expression to visit.</param>
        /// <returns>The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.</returns>
        public override Expression Visit(Expression expression)
        {
            if (expression != null)
            {
                bool saveCannotBeEvaluated = this.m_cannotBeEvaluated;

                this.m_cannotBeEvaluated = false;

                base.Visit(expression);

                if (!this.m_cannotBeEvaluated)
                {
                    if (this.m_fnCanBeEvaluated(expression))
                    {
                        this.m_candidates.Add(expression);
                    }
                    else
                    {
                        this.m_cannotBeEvaluated = true;
                    }
                }

                this.m_cannotBeEvaluated |= saveCannotBeEvaluated;
            }

            return expression;
        }

        /// <summary>
        /// Method Nominate.
        /// </summary>
        /// <param name="expression">The expression to check.</param>
        /// <returns>Expression candidates.</returns>
        internal HashSet<Expression> Nominate(Expression expression)
        {
            this.m_candidates = new HashSet<Expression>();

            this.Visit(expression);

            return this.m_candidates;
        }
    }
}
