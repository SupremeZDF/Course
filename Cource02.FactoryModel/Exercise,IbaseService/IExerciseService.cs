using Cource02.FactoryModel.Exercise.Model;
using Cource02.FactoryModel.Exercise.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise_IbaseService
{
    public interface IExerciseService<T> where T :ExerciseBaseModel
    {
        Result Add(T t);

        ExerciseResult Delete(T t);

        ExerciseResult Update(T t);

        ExerciseResult Select();
    }
}
