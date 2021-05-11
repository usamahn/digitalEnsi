using System;
using System.Linq;
using AutoMapper;
using digitalEnsi.DTO;
using digitalEnsi.Models;
using digitalEnsi.Models.DTO;

namespace digitalEnsi.Profiles
{


    public class MappingProfile:Profile{
        public MappingProfile(){
            CreateMap<RegistrationModel, Etudiant>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>DateTime.Parse(src.DateNaissance)));

            CreateMap<RegistrationModel, Enseignant>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>DateTime.Parse(src.DateNaissance)));

            CreateMap<Etudiant, EtudiantInfoModel>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>src.DateNaissance.Date.ToString("d")))
            .ForMember(dest=>dest.Niveau , opt=> {opt.MapFrom(src=>src.Inscriptions.LastOrDefault().Niveau);})
            .ForMember(dest=>dest.Groupe , opt=> opt.MapFrom(src=>src.Inscriptions.LastOrDefault().Groupe.Libellé_groupe));
            
            CreateMap<Enseignant, EtudiantInfoModel>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>src.DateNaissance.Date.ToString("d")));


            CreateMap<EtudiantInfoModel, UserUpdateModel>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>DateTime.Parse(src.DateNaissance)));

            CreateMap<EnseignantInfoModel, UserUpdateModel>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>DateTime.Parse(src.DateNaissance)));

            CreateMap<Enseignant, EnseignantInfoModel>()
            .ForMember(dest=>dest.DateNaissance , opt=> opt.MapFrom(src=>src.DateNaissance.Date.ToString("d")));

            CreateMap<Seance,SeanceEmploiModel>()
            .ForMember(dest=>dest.NomEnseignant,opt => opt.MapFrom(src=>src.Enseignant.Nom+" "+src.Enseignant.Prenom))
            .ForMember(dest=>dest.NomModule,opt => opt.MapFrom(src=>src.Module.LibelleModule))
            .ForMember(dest=>dest.Libellé_groupe,opt => opt.MapFrom(src=>src.Groupe.Libellé_groupe))
            .ForMember(dest=>dest.DateHeureDebut,opt => opt.MapFrom(src=>Utils.Utils.convertDate(src.Jour,src.HeureDeb)))
            .ForMember(dest=>dest.DateHeureFin,opt => opt.MapFrom(src=>Utils.Utils.convertDate(src.Jour,src.HeureFin)));

            CreateMap<Inscription,NoteModuleParGroupeModel>()
            .ForMember(dest=>dest.Nom,opt => opt.MapFrom(src=>src.Etudiant.Nom+" "+src.Etudiant.Prenom))
            .ForMember(dest=>dest.NoteId,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().NoteId))
            .ForMember(dest=>dest.NoteDs,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().NoteDs))
            .ForMember(dest=>dest.NoteCc,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().NoteCc))
            .ForMember(dest=>dest.NoteExamenP,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().NoteExamenP))
            .ForMember(dest=>dest.NoteExamenR,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().NoteExamenR))
            .ForMember(dest=>dest.MoyennePrincipal,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().getMoyennePrincipale()))
            .ForMember(dest=>dest.MoyenneRattrapage,opt => opt.MapFrom(src=>src.Notes.FirstOrDefault().getMoyenneRattrapage()));

            CreateMap<InscriptionModel,Inscription>();

        }
        
    }
}