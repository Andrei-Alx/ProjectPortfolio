package codecrusaders.business;

import codecrusaders.domain.*;
import codecrusaders.repository.entity.ErrorEntity;

import java.util.Optional;

public interface IErrorMessageManager {

    CreateErrorResponse createError(CreateErrorRequest request);
    GetErrorMessageResponse getAllErrorMessages();
    Optional<ErrorMessage> getErrorById(long id);
    GetSimilarErrorsResponse getSimilarErrorMessages(long id);
}
