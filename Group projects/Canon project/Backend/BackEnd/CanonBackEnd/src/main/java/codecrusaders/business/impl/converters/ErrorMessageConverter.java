package codecrusaders.business.impl.converters;

import codecrusaders.domain.ErrorMessage;
import codecrusaders.repository.entity.ErrorEntity;
import lombok.NoArgsConstructor;

@NoArgsConstructor
public class ErrorMessageConverter {
    public static ErrorMessage convert(ErrorEntity errorEntity) {
        return ErrorMessage.builder()
                .id(errorEntity.getErrorid())
                .message(errorEntity.getErrorMessage())
                .build();
    }
}
