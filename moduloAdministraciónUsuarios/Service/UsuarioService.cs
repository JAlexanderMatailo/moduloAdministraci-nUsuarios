﻿using dbPrueba;
using moduloAdministraciónUsuarios.ViewModel;

namespace moduloAdministraciónUsuarios.Service
{
    public class UsuarioService : IUsuario
    {
        pruebaContext _context;
        public UsuarioService(pruebaContext context)
        {
            _context = context;
        }

        #region Departamentos
        public List<Departamento> GetAllDepartamentos()
        {
            List<Departamento> listaDepartamento = new List<Departamento>();
            var departamento = _context.Departamentos.ToList();
            foreach (var department in departamento)
            {
                Departamento departamentos = new Departamento
                {
                    IdDepartamento = department.IdDepartamento,
                    nombreDepartamento = department.nombreDepartamento
                };
                listaDepartamento.Add(departamentos);
            };
            return listaDepartamento;
        }
        #endregion

        #region Cargos
        public List<Cargo> GetAllCargo()
        {
            List<Cargo> listaCargos = new List<Cargo>();
            var cargo = _context.Cargos.ToList();
            foreach (var cargos in cargo)
            {
                Cargo Ucargos = new Cargo
                {
                    IdCargos = cargos.IdCargos,
                    nombreCargo = cargos.nombreCargo
                };
                listaCargos.Add(Ucargos);
            }
            return listaCargos;
        }
        #endregion

        #region Usuarios
        public bool registrarUsuario(UserVM userVM)
        {

            var existe = _context.Users.Where(x => x.usuario == userVM.usuario).Any();
            bool registrado = false;
            if (!existe)
            {
                using (var context = _context.Database.BeginTransaction())
                {
                    try
                    {
                        User users = new User
                        {
                            usuario = userVM.usuario,
                            primerNombre = userVM.primerNombre,
                            segundoNombre = userVM.segundoNombre,
                            primerApellido = userVM.primerApellido,
                            segundoApellido = userVM.segundoApellido,
                            estado = userVM.estado,
                            email = userVM.email,
                            IdCargos = userVM.IdCargos,
                            IdDepartamentos = userVM.IdDepartamentos
                        };
                        _context.Users.Add(users);
                        _context.SaveChanges();

                        context.Commit();

                        registrado = true;
                    }
                    catch (Exception)
                    {
                        context.Rollback();
                        registrado = false;
                    }
                }
            }

            return registrado;
        }

        public List<UserVM> GetAll()
        {
            List<UserVM> listausers = new List<UserVM>();
            using (var context = _context.Database.BeginTransaction())
            {
                var consulta = (from usuario in _context.Users
                                join departamento in _context.Departamentos
                                on usuario.IdDepartamentos equals departamento.IdDepartamento
                                join cargos in _context.Cargos
                                on usuario.IdCargos equals cargos.IdCargos
                                where usuario.estado == true

                                select new
                                {
                                    usuario.IdUsers,
                                    usuario.usuario,
                                    usuario.primerNombre,
                                    usuario.primerApellido,
                                    IdDepartamentos = departamento.IdDepartamento,
                                    nombreDepartamentos = departamento.nombreDepartamento,
                                    IdCargo = cargos.IdCargos,
                                    nombresCargo = cargos.nombreCargo,
                                    usuario.email
                                }
                                );
                foreach (var user in consulta)
                {
                    UserVM userVM = new UserVM
                    {
                        usuario = user.usuario,
                        primerNombre = user.primerNombre,
                        primerApellido = user.primerApellido,
                        IdCargos = user.IdCargo,
                        IdDepartamentos = user.IdDepartamentos,
                        email = user.email
                    };
                    listausers.Add(userVM);
                }
            }
            return listausers;
        }

        public bool actualizarUser(UserVM user)
        {
            var usuarioExiste = _context.Users.FirstOrDefault(x => x.usuario == user.usuario);
            if (usuarioExiste != null)
            {
                usuarioExiste.usuario = user.usuario;
                usuarioExiste.primerNombre = user.primerNombre;
                usuarioExiste.segundoNombre = user.segundoNombre;
                usuarioExiste.primerApellido = user.primerApellido;
                usuarioExiste.segundoApellido = user.segundoApellido;
                usuarioExiste.email = user.email;
                usuarioExiste.estado = user.estado;
                usuarioExiste.IdCargos = user.IdCargos;
                usuarioExiste.IdDepartamentos = user.IdDepartamentos;

                try
                {
                    _context.SaveChanges();
                    return true;
                } catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public bool eliminarUser(string nombreUsuario)
        {
            var usuarioExiste = _context.Users.FirstOrDefault(x => x.usuario == nombreUsuario);
            if(usuarioExiste != null)
            {
                usuarioExiste.estado = false;

                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
        #endregion
    }
}
