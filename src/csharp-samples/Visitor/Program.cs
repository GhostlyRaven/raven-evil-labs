using System;

// ReSharper disable All

namespace Visitor
{
    public static class Program
    {
        public static void Main()
        {
            IComputerVisitor1 visitor1 = new ComputerVisitor1();

            Computer1 computer1 = new Intel1();

            computer1.Accept(visitor1);

            Computer1 computer2 = new Amd1();

            computer2.Accept(visitor1);

            Console.WriteLine();

            IComputerVisitor2 visitor2 = new ComputerVisitor2();

            Computer2 computer3 = new Intel2();

            computer3.Accept(visitor2);

            Computer2 computer4 = new Amd2();

            computer4.Accept(visitor2);

            Console.WriteLine();

            ComputerVisitor3 visitor3 = new ComputerVisitor3();

            Computer3<Intel3> computer5 = new Intel3();

            computer5.Accept(visitor3);

            Computer3<Amd3> computer6 = new Amd3();

            computer6.Accept(visitor3);

            Console.ReadKey();
        }
    }

    #region Version 1

    public interface IComputerVisitor1
    {
        void Visit(Intel1 computer);

        void Visit(Amd1 computer);
    }

    public class ComputerVisitor1 : IComputerVisitor1
    {
        public void Visit(Intel1 computer)
        {
            Console.WriteLine(computer.Name);
        }

        public void Visit(Amd1 computer)
        {
            Console.WriteLine(computer.Name);
        }
    }

    public abstract class Computer1
    {
        public virtual string Name { get; }

        public abstract void Accept(IComputerVisitor1 visitor);
    }

    public class Intel1 : Computer1
    {
        public override string Name => nameof(Intel1);

        public override void Accept(IComputerVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Amd1 : Computer1
    {
        public override string Name => nameof(Amd1);

        public override void Accept(IComputerVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }

    #endregion

    #region Version 2

    public interface IComputerVisitor2
    {
        void Visit(Computer2 computer);
    }

    public class ComputerVisitor2 : IComputerVisitor2
    {
        public void Visit(Computer2 computer)
        {
            Console.WriteLine(computer.Name);
        }
    }

    public abstract class Computer2
    {
        public virtual string Name { get; }

        public abstract void Accept(IComputerVisitor2 visitor);
    }

    public class Intel2 : Computer2
    {
        public override string Name => nameof(Intel2);

        public override void Accept(IComputerVisitor2 visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Amd2 : Computer2
    {
        public override string Name => nameof(Amd2);

        public override void Accept(IComputerVisitor2 visitor)
        {
            visitor.Visit(this);
        }
    }

    #endregion

    #region Version 3

    public interface IComputerVisitor3<TEntity>
    {
        void Visit(TEntity entity);
    }

    public class ComputerVisitor3 : IComputerVisitor3<Intel3>, IComputerVisitor3<Amd3>
    {
        public void Visit(Intel3 entity)
        {
            Console.WriteLine(entity.Name);
        }

        public void Visit(Amd3 entity)
        {
            Console.WriteLine(entity.Name);
        }
    }

    public abstract class Computer3<TEntity>
    {
        public virtual string Name { get; }

        public abstract void Accept(IComputerVisitor3<TEntity> visitor);
    }

    public class Intel3 : Computer3<Intel3>
    {
        public override string Name => nameof(Intel3);

        public override void Accept(IComputerVisitor3<Intel3> visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Amd3 : Computer3<Amd3>
    {
        public override string Name => nameof(Amd3);

        public override void Accept(IComputerVisitor3<Amd3> visitor)
        {
            visitor.Visit(this);
        }
    }

    #endregion
}
