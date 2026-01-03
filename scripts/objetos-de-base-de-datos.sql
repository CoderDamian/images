-- ================================================================
-- Create the tables, editioning views, triggers, and sequences
-- Aplication: MyContabilidad
-- Schema: CTB
-- Date: 2023.05.16
-- Note: Ejecutarlo como usuario ctb
-- =================================================================

prompt -> connecting the user CTB ...
connect ctb/&pass_cia_data@&connection_string

prompt -> creating table CATEGORIAS ...
create table categorias# (
      categoria_id       number(5, 0) 
    , categoria_padre_fk number(5, 0)
    , nombre             nvarchar2(100) not null
    , created_by         nvarchar2(25) not null
    , created_date       timestamp default current_timestamp
    , updated_by         nvarchar2(25)
    , updated_date       timestamp
);

prompt -> adding comments to columns ...        
comment on column categorias#.categoria_id is 'identificador unico de la categoria';

prompt -> creating constrains ...    
alter table categorias# 
    add constraint cate_pk 
        primary key ( categoria_id );

alter table categorias#
    add constraint cate_to_cate_fk foreign key ( categoria_padre_fk )
        references categorias# ( categoria_id )
            on delete set null;

-- Creating the editioning view
Prompt -> creating the editioning view ...
create or replace editioning view categorias as
    select
        *
    from
        categorias#;

-- Creating the sequence
prompt -> creating the sequence
create sequence cate_id_seq start with 1 increment by 1 nocache nocycle;

prompt ->  creating triggers ...
-- obtener la clave primaria antes de insertar el registro
create or replace trigger cate_bi_get_id_trg before
    insert on categorias#
    for each row
begin
    lock table categorias# in share mode;
    :new.categoria_id := cate_id_seq.nextval;
end;

-- si el registro es actualizado, entonces el campo updated_by debe tener un valor
create or replace trigger cate_bu_check_who_is_trg before
    update on categorias#
    for each row
declare
    l_updated_date timestamp;
    l_mensaje      varchar2(100) := 'Si el registro es actualizado, entonces los campos updated_by, updated_date deben tener un valor'
    ;
begin
    if ( :new.updated_by is null ) then
        raise_application_error(-20000, l_mensaje);
    else
        select
            current_timestamp(3)
        into l_updated_date
        from
            dual;

        :new.updated_date := l_updated_date;
    end if;
end;