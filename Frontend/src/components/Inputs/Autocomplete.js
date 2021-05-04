import React from 'react';
import TextField from '@material-ui/core/TextField';
import CircularProgress from '@material-ui/core/CircularProgress';

import Autocomplete from '@material-ui/lab/Autocomplete';

import {
    Button,
    Card,
    CardHeader,
    CardBody,
    FormGroup,
    Form,
    Input,
    InputGroupAddon,
    InputGroupText,
    InputGroup,
    Modal,
    Row,
    Col
  } from "reactstrap";

export default function CustomAutocomplete(props) {
    const [open, setOpen] = React.useState(false);
    const [options, setOptions] = React.useState([]);
    const loading = open && options.length === 0;
  
    React.useEffect(() => {
      let active = true;
  
      if (!loading) {
        return undefined;
      }
  
      (async () => {
        const response = await props.getOptions()
  
        if (active) {
          setOptions(response.data);
        }
      })();
  
      return () => {
        active = false;
      };
    }, [loading]);
  
    React.useEffect(() => {
      if (!open) {
        setOptions([]);
      }
    }, [open]);
  
    return (
      <Autocomplete
        
        style={{ width: 300, marginTop:"27px" }}
        open={open}
        onOpen={() => {
          setOpen(true);
        }}
        onClose={() => {
          setOpen(false);
        }}
        
        onChange={props.onChange}
        //value={/*props.eleveAutocompleteValue*/}
        //getOptionSelected={(option, value) => (option.cin_Eleve === value.cin_Eleve)}
        getOptionLabel={props.getOptionLabel}
        options={options}
        loading={loading}
        renderInput={(params) => (
            
            <TextField
            {...params}
            label=""
            variant="outlined"
            InputProps={{
              ...params.InputProps,
              endAdornment: (
                <React.Fragment>
                  {loading ? <CircularProgress color="inherit" size={20} /> : null}
                  {params.InputProps.endAdornment}
                </React.Fragment>
              ),
            }}
          />
        )}
            
       
  
        renderOption={props.renderOption}
      />
    );
  }