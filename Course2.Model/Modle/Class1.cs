using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Course2.Model
{
    public class Class1
    {
        public static void showTS<T, S>(T a,S b)
            where T :People
            where S:T
        {

        }

        public void Name() 
        {
            showTS<People, A>(new A() { }, new A() { });
            List<string> vs = new List<string>();
            //vs.Add();
        }
    }

    public class People 
    {
        //所谓协变逆变 都是跟泛型相关  out 协变 in 逆变

        //协变：可以让右边用上子类  out 协变只能用在接口或委托上 只能作为返回值 不能作为参数
        IEnumerable<A> As = new List<B>();
       
        
        //IEnumerable<A> as2 = new IEnumerable<B>();

        //逆变 in ,只能入参 没有返回值 用右边
        ICustomer<A> customer = new CustomerMer<B>();

        ICustomerIn<B> customers = new CustomerMerIn<A>();
        

        public void Na() 
        {
            //ICustomerIn<A> customerIn = new ICustomerIn<A>();
            List<ICustomer<A>> aa = new List<ICustomer<A>>();
            aa.Add(new CustomerMer<B>());
            List<ICustomerIn<B>> bb = new List<ICustomerIn<B>>();
            bb.Add(new CustomerMerIn<A>());
            //As.
            var c = customer.Name();
            var a = customer.Name();
            customers.Name(new B());
        }
    }

    public class A : People
    {
    
    }

    public class B :A
    {
    
    }

    public class C : B 
    {
     
    }


    public interface ICustomer<out T>
    {
        T Name();

        //T GetT(T a);
    }

    public class CustomerMer<T> : ICustomer<T>
    {
        public T Name()
        {
            throw new NotImplementedException();
        }
    }

    public interface ICustomerIn<in T>
    {
        void Name(T name);

        //T GetT(T a);
    }

    public class CustomerMerIn<T> : ICustomerIn<T>
    {
        public void Name(T name)
        {
            throw new NotImplementedException();
        }
    }
}
