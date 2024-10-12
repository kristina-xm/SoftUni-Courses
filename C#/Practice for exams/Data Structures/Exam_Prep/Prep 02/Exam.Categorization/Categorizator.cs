using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualBasic;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        Dictionary<string, Category> categories = new Dictionary<string, Category>();
        public void AddCategory(Category category)
        {
            if (categories.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            category.Depth = 0;
            categories.Add(category.Id, category);
           
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!categories.ContainsKey(childCategoryId) || !categories.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            var childCategory = categories[childCategoryId];
            var parentCategory = categories[parentCategoryId];

            if (parentCategory.Children.Contains(childCategory))
            {
                throw new ArgumentException();
            }

            childCategory.Parent = parentCategory;
            parentCategory.Children.Add(childCategory);

            var ancestor = parentCategory;
            while (ancestor.Parent != null)
            {
                ancestor = ancestor.Parent;
            }

            UpdateParentDepth(ancestor);
        }

        private int UpdateParentDepth(Category ancestor)
        {
            if (ancestor == null)
            {
                return 0;
            }

            var depth = 0;

            foreach (var child in ancestor.Children)
            {
                depth = Math.Max(depth, UpdateParentDepth(child));
            }

            ancestor.Depth = depth + 1;

            return ancestor.Depth;

        }

        public bool Contains(Category category)
        {
           return categories.ContainsKey(category.Id);
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var children = new HashSet<Category>();

           GetAllChildren(categoryId, children);

           return children;
        }

        private void GetAllChildren(string categoryId, HashSet<Category> children)
        {
            foreach (var child in categories[categoryId].Children)
            {
                children.Add(child);
                GetAllChildren(child.Id, children);
            }
            //here we do not need end of recursion as the foreach loop is enough
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var stack = new Stack<Category>();

            GetAllPatentsRecursively(categories[categoryId], stack);

            return stack;
        }

        private void GetAllPatentsRecursively(Category category, Stack<Category> stack)
        {
            if (category == null)
            {
                return;
            }

            stack.Push(category);
            GetAllPatentsRecursively(category.Parent, stack);

        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            return categories.Values.OrderByDescending(cat => cat.Depth)
                .ThenBy(cat => cat.Name)
                .Take(3);
        }

        public void RemoveCategory(string categoryId)
        {
            if (!categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var category = categories[categoryId];
            categories.Remove(categoryId);

            RemoveChildrenRecursively(category);

            if (category.Parent != null)
            {
                category.Parent.Children.Remove(category);
            }

        }

        private void RemoveChildrenRecursively(Category category)
        {
            foreach (var child in category.Children)
            {
                RemoveChildrenRecursively(child);
                categories.Remove(child.Id);
            }
        }

        public int Size() => categories.Count;
        
    }
}
