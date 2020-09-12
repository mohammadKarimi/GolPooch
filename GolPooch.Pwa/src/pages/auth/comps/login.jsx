import React, { useState } from 'react';
import { TextField, FormControlLabel, Checkbox } from '@material-ui/core';
import strings from './../../../core/strings';
import Button from './../../../core/comps/Button';

export default function () {
    const [inProgress, setInProgress] = useState(false);
    const [mobileNumber, setMobileNumber] = useState({
        value: '',
        error: false,
        errorMessage: ''
    });
    const [ruleAgreement, setRuleAgreement] = useState(false);

    const _submit = () => {
        
    }
    return (<div id='comp-login'>
        <div className="form-group">
            <TextField
                error={mobileNumber.error}
                id="mobileNumber"
                name="mobileNumber"
                placeholder="9xxxxxxxxx"
                label={strings.mobileNumber}
                value={mobileNumber.value}
                onChange={(e) => setMobileNumber({ value: e.target.value, error: false, errorMessage: '' })}
                helperText={mobileNumber.errorMessage}
                style={{ fontFamily: 'iransans' }}
                variant="outlined"
            />
        </div>
        <div className="form-group">
            <FormControlLabel
                control={<Checkbox color="primary" checked={ruleAgreement} onChange={() => setRuleAgreement(!ruleAgreement)} name="ruleAgreement" />}
                label={strings.aggreedWithRules} />
        </div>
        <div className="form-group">
            <Button onClick={() => _submit()} loading={inProgress} disabled={inProgress} className='btn-primary'>{strings.signInToSystem}</Button>
        </div>
    </div>);
}